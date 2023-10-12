using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UIElements;

public class DialogScreen : MonoBehaviour
{
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
    [SerializeField] private int currentDialogIndex = -1;
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

    Button m_ClickButton;

    Button m_SkipButton;
    Button m_FFButton;
    Button m_AutoButton;

    VisualElement m_CenterImage;
    VisualElement m_RightImage;
    VisualElement m_LeftImage;

    Label m_Name;
    Label m_Text;

    VisualElement m_Next;

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
            if(dialogDB.DialogDB[i].branch == branch)
            {
                dialogs.Add(dialogDB.DialogDB[i]);
            }
        }
        currentDialogIndex = (int)dialogs[0].idx-1;
        ShowScreen();
        Start();
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
    }

    void ScreenClicked(ClickEvent evt)
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
    private IEnumerator Start()
    {
        yield return new WaitUntil(()=>UpdateDialog());

        yield return new WaitForSeconds(2);
        Debug.Log("대화종료");
        //UnityEditor.EditorApplication.ExitPlaymode();
    }
}