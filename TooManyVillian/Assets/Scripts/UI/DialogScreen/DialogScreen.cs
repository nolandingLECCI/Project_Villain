using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UIElements;

public class DialogScreen : MonoBehaviour
{
    string m_ResourcePath = "GameData/Dialog";
    private uint Question1Idx;
    private uint Question2Idx;
    private uint Question3Idx;

    [SerializeField] private Sprite m_DefaultImage; 
    //Screen Settings
    [SerializeField] protected UIDocument m_Document;
    protected VisualElement m_Screen;
    protected VisualElement m_Root;

    public event Action ScreenStarted;
    public event Action ScreenEnded;

    //Dialog System
    [SerializeField] private Dialog dialogDB;
    [SerializeField] private List<DialogEntity> dialogs;
    
    public int branch = 1;
    private bool isAutoStart = true;
    private bool isFirst = true;
    private bool playOnlyFirstTime = true;
    [SerializeField] private int currentDialogIndex = 0;
    private int currentSpeakerIndex = 0;
    private float defaultTypingSpeed = 0.1f;
    private float ffTypingSpeed = 0.05f;
    private bool fastForward = false;

    private bool isTypingEffect = false;


    //UI Settings
    const string k_ClickButton = "Dialog_Click-button";

    const string k_SkipButton = "Dialog_Menu-skip_button";
    const string k_FFButton = "Dialog_Menu-ff_button";
    const string k_AutoButton = "Dialog_Menu-auto_button";

    const string k_CenterImage = "Dialog_Image-center";
    const string k_LeftImage = "Dialog_Image-left";
    const string k_RightImage = "Dialog_Image-right";

    const string k_Name = "Dialog_Text-name";
    const string k_Text = "Dialog_Text-text";

    const string k_Next = "Dialog_Text-next";

    const string k_SpeakingClass = "Speaking";
    const string k_NotSpeakingClass = "NotSpeaking";
    const string k_NotSpeakingLeftClass = "NotSpeaking-left";
    const string k_NotSpeakingRightClass = "NotSpeaking-right";

    const string k_QuestionActive = "question_active";
    const string k_QuestionInactive = "question_inactive";

    const string k_Question = "Questions";

    Button m_ClickButton;

    Button m_SkipButton;
    Button m_FFButton;
    Button m_AutoButton;

    Button m_Question_1_Button;
    Button m_Question_2_Button;
    Button m_Question_3_Button;

    Label m_Question_1_Label;
    Label m_Question_2_Label;
    Label m_Question_3_Label;

    VisualElement m_CenterImage;
    VisualElement m_RightImage;
    VisualElement m_LeftImage;

    Label m_Name;
    Label m_Text;

    VisualElement m_Next;

    void Start()
    {
        LoadData();
    }
    protected virtual void Awake()
    {
        if (m_Document == null)
            m_Document = GetComponent<UIDocument>();
        else
        {
            SetVisualElements();
            RegisterButtonCallbacks();
        }
        Setup();
    }

    void OnEnable()
    {
        dialogs = new List<DialogEntity>();
        for(int i = 0 ; i < dialogDB.DialogDB.Count; ++i)
        {
            if(i==0)
            {
                currentDialogIndex = (int)dialogDB.DialogDB[i].idx-1;
            }
            if(dialogDB.DialogDB[i].branch == branch)
            {
                dialogs.Add(dialogDB.DialogDB[i]);
            }
        }
        SetNextDialog();
        ShowScreen();
        DialogStart();
    }

    private void SetVisualElements()
    {
        if (m_Document != null)
                m_Root = m_Document.rootVisualElement;
        m_Screen = m_Root.Q("DialogScreen");

        m_ClickButton = m_Root.Q<Button>(k_ClickButton);

        m_SkipButton = m_Root.Q<Button>(k_SkipButton);
        m_FFButton = m_Root.Q<Button>(k_FFButton);
        m_AutoButton = m_Root.Q<Button>(k_AutoButton);

        m_Question_1_Button = m_Root.Q<Button>(k_Question+"-1");
        m_Question_2_Button = m_Root.Q<Button>(k_Question+"-2");
        m_Question_3_Button = m_Root.Q<Button>(k_Question+"-3");

        m_Question_1_Label = m_Root.Q<Label>(k_Question+"-1_text");
        m_Question_2_Label = m_Root.Q<Label>(k_Question+"-2_text");
        m_Question_3_Label = m_Root.Q<Label>(k_Question+"-3_text");

        m_CenterImage = m_Root.Q<VisualElement>(k_CenterImage);
        m_LeftImage = m_Root.Q<VisualElement>(k_LeftImage);
        m_RightImage = m_Root.Q<VisualElement>(k_RightImage);

        m_Name= m_Root.Q<Label>(k_Name);
        m_Text= m_Root.Q<Label>(k_Text);

        m_Next = m_Root.Q<VisualElement>(k_Next);
    }
    private void RegisterButtonCallbacks()
    {
        m_ClickButton?.RegisterCallback<ClickEvent>(ScreenClicked);

        m_SkipButton?.RegisterCallback<ClickEvent>(Skip);
        m_FFButton?.RegisterCallback<ClickEvent>(FF);
        m_AutoButton?.RegisterCallback<ClickEvent>(Auto);

        m_Question_1_Button?.RegisterCallback<ClickEvent>(Question1);
        m_Question_2_Button?.RegisterCallback<ClickEvent>(Question2);
        m_Question_3_Button?.RegisterCallback<ClickEvent>(Question3);
    }

    void ScreenClicked(ClickEvent evt)
    {
        if(dialogs[currentDialogIndex+1].type == "dialog")
        {
            if(isTypingEffect == true)
            {
                isTypingEffect = false;
                StopCoroutine("OnTypingText");
                m_Text.text = dialogs[currentDialogIndex].dialog;
                //speakers[currentSpeakerIndex].objectArrow.SetActive(true);
            }
            if(dialogs.Count > currentDialogIndex + 1)
            {
                SetNextDialog();
            }
            else
            {
                Debug.Log("Dialog End");
            }
        }
        else
        {
            if(dialogs.Count > currentDialogIndex + 1)
            {
                if(dialogs[currentDialogIndex+1].type == "question")
                {
                    m_Question_1_Label.text = dialogs[currentDialogIndex+1].dialog;
                    m_Question_1_Button.RemoveFromClassList(k_QuestionInactive);
                    m_Question_1_Button.AddToClassList(k_QuestionActive);
                    Question1Idx = dialogs[currentDialogIndex+1].nextIdx;
                }
                if(dialogs[currentDialogIndex+2].type == "question")
                {
                    m_Question_2_Button.RemoveFromClassList(k_QuestionInactive);
                    m_Question_2_Button.AddToClassList(k_QuestionActive);
                    m_Question_2_Label.text = dialogs[currentDialogIndex+2].dialog;
                    Question2Idx = dialogs[currentDialogIndex+2].nextIdx;
                }
                if(dialogs[currentDialogIndex+3].type == "question")
                {
                    m_Question_3_Button.RemoveFromClassList(k_QuestionInactive);
                    m_Question_3_Button.AddToClassList(k_QuestionActive);
                    m_Question_3_Label.text = dialogs[currentDialogIndex+3].dialog;
                    Question3Idx = dialogs[currentDialogIndex+3].nextIdx;
                }
            }
        }
    }
    void Skip(ClickEvent evt)
    {
        
    }
    void FF(ClickEvent evt)
    {
        if(!fastForward)    fastForward = true;
        else                fastForward = false;
    }
    void Auto(ClickEvent evt)
    {
        if(!isAutoStart)    isAutoStart = true;
        else                isAutoStart = false;
    }
    void Question1(ClickEvent evt)
    {
        currentDialogIndex = (int)Question1Idx;
        InactiveQuestions();
        SetNextDialog();
    }
    void Question2(ClickEvent evt)
    {
        currentDialogIndex = (int)Question2Idx;
        InactiveQuestions();
        SetNextDialog();
    }
    void Question3(ClickEvent evt)
    {
        currentDialogIndex = (int)Question2Idx;
        InactiveQuestions();
        SetNextDialog();
    }
    

    public bool IsVisible()
    {
        if (m_Screen == null)
            return false;

        return (m_Screen.style.display == DisplayStyle.Flex);
    }

    
    public static void ShowVisualElement(VisualElement visualElement, bool state)
    {
        if (visualElement == null)
            return;

        visualElement.style.display = (state) ? DisplayStyle.Flex : DisplayStyle.None;
    }

    
    public VisualElement GetVisualElement(string elementName)
    {
        if (string.IsNullOrEmpty(elementName) || m_Root == null)
            return null;

        
        return m_Root.Q(elementName);
    }

    public virtual void ShowScreen()
    {
        ShowVisualElement(m_Screen, true);
        ScreenStarted?.Invoke();
    }

    public virtual void HideScreen()
    {
        if (IsVisible())
        {
            ShowVisualElement(m_Screen, false);
            ScreenEnded?.Invoke();
        }
    }

    private void Setup()
    {
        InactiveQuestions();
    }

    public bool UpdateDialog()
    {
        if(isFirst == true)
        {
            if(isAutoStart) SetNextDialog();
            isFirst = false;
        }
        return false;
    }
    private void SetNextDialog()
    {
        currentDialogIndex++;
        m_Text.text = dialogs[currentDialogIndex].dialog;
        m_Name.text = dialogs[currentDialogIndex].name;
        string SpeakerName = dialogs[currentDialogIndex].name;
        string SpeakerEmotion = dialogs[currentDialogIndex].emotion;
        uint SpeakerIdx = dialogs[currentDialogIndex].speakerIdx;
        Sprite SpeakerImage = Resources.Load<Sprite>(m_ResourcePath+"/"+SpeakerName+"/"+SpeakerName+"_"+SpeakerEmotion);

        
        if(currentDialogIndex>0)
        {
            Debug.Log(SpeakerName!=dialogs[currentDialogIndex+1].name&&SpeakerIdx==dialogs[currentDialogIndex+1].speakerIdx);
            StartCoroutine(HighlightSpeaker(SpeakerIdx, SpeakerName!=dialogs[currentDialogIndex-1].name&&SpeakerIdx==dialogs[currentDialogIndex-1].speakerIdx, SpeakerImage));
        }
        else    StartCoroutine(HighlightSpeaker(SpeakerIdx, true, SpeakerImage));
        //StartCoroutine("OnTypingText");
    }
    private IEnumerator OnTypingText()
    {
        int idx = 0;
        float typingSpeed = defaultTypingSpeed;

        isTypingEffect = true;

        while(idx < m_Text.text.Length)
        {
            m_Text.text = m_Text.text.Substring(0,idx);
            idx++;

            if(!fastForward)    typingSpeed = defaultTypingSpeed;
            else                typingSpeed = ffTypingSpeed;

            yield return new WaitForSeconds(typingSpeed);
        }

        isTypingEffect = false;

        //speakers[currentSpeakerIndex].objectArrow.SetActive(true);
    }
    private IEnumerator DialogStart()
    {
        yield return new WaitUntil(()=>UpdateDialog());

        yield return new WaitForSeconds(2);
        Debug.Log("대화종료");
        //UnityEditor.EditorApplication.ExitPlaymode();
    }

    private void LoadData()
    {
        m_DefaultImage = Resources.Load<Sprite>(m_ResourcePath+"/Default");
    }
    IEnumerator HighlightSpeaker(uint idx, bool sameSpeakerIdx, Sprite img)
    {
        switch(idx)
        {
            case 0:
                if(sameSpeakerIdx)
                {
                    Debug.Log("same idx, differnt name");
                    m_LeftImage.RemoveFromClassList(k_SpeakingClass);
                    m_LeftImage.AddToClassList(k_NotSpeakingLeftClass);
                    yield  return new WaitForSecondsRealtime(0.25f);
                }
                if(img == null)
                {
                    m_LeftImage.style.backgroundImage = new StyleBackground(m_DefaultImage);
                }
                else
                {
                    m_LeftImage.style.backgroundImage = new StyleBackground(img);
                }
                m_LeftImage.RemoveFromClassList(k_NotSpeakingLeftClass);
                m_LeftImage.AddToClassList(k_SpeakingClass);
                m_RightImage.RemoveFromClassList(k_SpeakingClass);
                m_RightImage.AddToClassList(k_NotSpeakingRightClass);
                m_CenterImage.RemoveFromClassList(k_SpeakingClass);
                m_CenterImage.AddToClassList(k_NotSpeakingClass);
                break;
            case 1:
               if(sameSpeakerIdx)
                {
                    m_RightImage.RemoveFromClassList(k_SpeakingClass);
                    m_RightImage.AddToClassList(k_NotSpeakingRightClass);
                    yield  return new WaitForSecondsRealtime(0.25f);
                }
                if(img == null)
                {
                    m_RightImage.style.backgroundImage = new StyleBackground(m_DefaultImage);
                }
                else
                {
                    m_RightImage.style.backgroundImage = new StyleBackground(img);
                }
                m_LeftImage.RemoveFromClassList(k_SpeakingClass);
                m_LeftImage.AddToClassList(k_NotSpeakingLeftClass);
                m_RightImage.RemoveFromClassList(k_NotSpeakingRightClass);
                m_RightImage.AddToClassList(k_SpeakingClass);
                m_CenterImage.RemoveFromClassList(k_SpeakingClass);
                m_CenterImage.AddToClassList(k_NotSpeakingClass);
                break;
            case 2:
                if(sameSpeakerIdx)
                {
                    m_CenterImage.RemoveFromClassList(k_SpeakingClass);
                    m_CenterImage.AddToClassList(k_NotSpeakingLeftClass);
                    yield  return new WaitForSecondsRealtime(0.25f);
                }
                if(img == null)
                {
                    m_CenterImage.style.backgroundImage = new StyleBackground(m_DefaultImage);
                }
                else
                {
                    m_CenterImage.style.backgroundImage = new StyleBackground(img);
                }
                m_LeftImage.RemoveFromClassList(k_SpeakingClass);
                m_LeftImage.AddToClassList(k_NotSpeakingLeftClass);
                m_RightImage.RemoveFromClassList(k_SpeakingClass);
                m_RightImage.AddToClassList(k_NotSpeakingRightClass);
                m_CenterImage.RemoveFromClassList(k_NotSpeakingClass);
                m_CenterImage.AddToClassList(k_SpeakingClass);
                break;
        }
        yield break;
    }
    private void InactiveQuestions()
    {
        m_Question_1_Button.RemoveFromClassList(k_QuestionActive);
        m_Question_1_Button.AddToClassList(k_QuestionInactive);
        m_Question_2_Button.RemoveFromClassList(k_QuestionActive);
        m_Question_2_Button.AddToClassList(k_QuestionInactive);
        m_Question_3_Button.RemoveFromClassList(k_QuestionActive);
        m_Question_3_Button.AddToClassList(k_QuestionInactive);
    }
}