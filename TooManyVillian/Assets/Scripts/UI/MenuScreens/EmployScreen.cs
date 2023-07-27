using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class EmployScreen : MenuScreen
{
    public static event Action GetRandomCharacter;

    //buttons
    const string k_EmployButton = "select-button__Employ";
    const string k_ScoutButton = "select-button__Scout";
    const string k_PoolButton = "select-button__Pool";

    const string k_EmployYesButton = "progress-yes_employ";
    const string k_EmployNoButton = "progress-no_employ";
    const string k_ScoutYesButton = "progress-yes_scout";
    const string k_ScoutNoButton = "progress-no_scout";
    const string k_PoolYesButton = "progress-yes_pool";
    const string k_PoolNoButton = "progress-no_pool";
    //labels
    const string k_CurrentPool = "employ-screen__pool-count";
    const string k_Capacity = "employ-screen__pool-max";
    //visualElements
    const string k_MainPanel = "EmployScreen--Main_panel";
    const string k_EmployPanel = "EmployScreen--Employ_panel";
    const string k_ScoutPanel = "EmployScreen--Scout_panel";
    const string k_PoolPanel = "EmployScreen--Pool_panel";

    const string k_ProgressEmployScreen = "ProgressScreen--Employ";
    const string k_ProgressScoutScreen = "ProgressScreen--Scout";
    const string k_ProgressPoolScreen = "ProgressScreen--Pool";

    const string k_ProgressEmployPanel = "progress__panel--employ";
    const string k_ProgressScoutPanel = "progress__panel--scout";
    const string k_ProgressPoolPanel = "progress__panel--pool";
    //class
    const string k_PanelActiveClass = "panel__active";
    const string k_PanelInactiveClass = "panel__inactive";

    const string k_ProgressActiveClass = "progress__panel";
    const string k_ProgressInActiveClass = "progress__panel--inactive";


    const float k_LerpTime = 0.6f;

    Button m_EmployButton;
    Button m_ScoutButton;
    Button m_PoolButton;

    Button m_EmployYesButton;
    Button m_EmployNoButton;
    Button m_ScoutYesButton;
    Button m_ScoutNoButton;
    Button m_PoolYesButton;
    Button m_PoolNoButton;

    Label m_CurrentPool;
    Label m_Capacity;
    
    VisualElement m_MainPanel;
    VisualElement m_EmployPanel;
    VisualElement m_ScoutPanel;
    VisualElement m_PoolPanel;

    VisualElement m_ProgressEmployScreen;
    VisualElement m_ProgressScoutScreen;
    VisualElement m_ProgressPoolScreen;

    VisualElement m_ProgressEmployPanel;
    VisualElement m_ProgressScoutPanel;
    VisualElement m_ProgressPoolPanel;

    VisualElement m_CurrentPanel;

    private void OnEnable()
    {
        GameDataManager.PoolUpdated += OnPoolUpdated;
    }

    private void OnDisable()
    {
        GameDataManager.PoolUpdated -= OnPoolUpdated;
    }

    void OnPoolUpdated(GameData gameData)
    {
        SetCurrentPool((uint)gameData.CharaData.Count);
        SetCapcity(gameData.CharaCap);
    }

    void SetCurrentPool(uint pool)
    {
        uint startValue = (uint)Int32.Parse(m_CurrentPool.text);
        StartCoroutine(LerpRoutine(m_CurrentPool, startValue, pool, k_LerpTime));
    }
    void SetCapcity(uint cap)
    {
        uint startValue = (uint)Int32.Parse(m_Capacity.text);
        StartCoroutine(LerpRoutine(m_Capacity, startValue, cap, k_LerpTime));
    }

    IEnumerator LerpRoutine(Label label, uint startValue, uint endValue, float duration)
    {
        float lerpValue = (float) startValue;
        float t = 0f;
        label.text = string.Empty;

        while (Mathf.Abs((float)endValue - lerpValue) > 0.05f)
        {
            t += Time.deltaTime / k_LerpTime;

            lerpValue = Mathf.Lerp(startValue, endValue, t);
            label.text = lerpValue.ToString("0");
            yield return null;
        }
        label.text = endValue.ToString();
    }


    // identify visual elements by name
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_EmployButton = m_Root.Q<Button>(k_EmployButton);
        m_ScoutButton = m_Root.Q<Button>(k_ScoutButton);
        m_PoolButton = m_Root.Q<Button>(k_PoolButton);

        m_EmployYesButton = m_Root.Q<Button>(k_EmployYesButton);
        m_EmployNoButton = m_Root.Q<Button>(k_EmployNoButton);
        m_ScoutYesButton = m_Root.Q<Button>(k_ScoutYesButton);
        m_ScoutNoButton = m_Root.Q<Button>(k_ScoutNoButton);
        m_PoolYesButton = m_Root.Q<Button>(k_PoolYesButton);
        m_PoolNoButton = m_Root.Q<Button>(k_PoolNoButton);
       

        m_CurrentPool = m_Root.Q<Label>(k_CurrentPool);
        m_Capacity = m_Root.Q<Label>(k_Capacity);

        m_MainPanel = m_Root.Q(k_MainPanel);
        m_EmployPanel = m_Root.Q(k_EmployPanel);
        m_ScoutPanel = m_Root.Q(k_ScoutPanel);
        m_PoolPanel = m_Root.Q(k_PoolPanel);

        m_ProgressEmployScreen = m_Root.Q(k_ProgressEmployScreen);
        m_ProgressScoutScreen = m_Root.Q(k_ProgressScoutScreen);
        m_ProgressPoolScreen = m_Root.Q(k_ProgressPoolScreen);

        m_ProgressEmployPanel = m_Root.Q(k_ProgressEmployPanel);
        m_ProgressScoutPanel = m_Root.Q(k_ProgressScoutPanel);
        m_ProgressPoolPanel = m_Root.Q(k_ProgressPoolPanel);

        m_CurrentPanel = m_MainPanel;
    }

    // set up button click events
    protected override void RegisterButtonCallbacks()
    {
        m_EmployButton?.RegisterCallback<ClickEvent>(ShowProgressEmploy);
        m_ScoutButton?.RegisterCallback<ClickEvent>(ShowProgressScout);
        m_PoolButton?.RegisterCallback<ClickEvent>(ShowProgressPool);

        m_EmployYesButton?.RegisterCallback<ClickEvent>(ShowEmployPanel);
        m_EmployYesButton?.RegisterCallback<ClickEvent>(GetCharacter);

        m_EmployNoButton?.RegisterCallback<ClickEvent>(HideProgressEmploy);
        m_ScoutYesButton?.RegisterCallback<ClickEvent>(ShowScoutPanel);
        m_ScoutNoButton?.RegisterCallback<ClickEvent>(HideProgressScout);
        m_PoolYesButton?.RegisterCallback<ClickEvent>(ShowPoolPanel);
        m_PoolNoButton?.RegisterCallback<ClickEvent>(HideProgressPool);
    }
    ///////////////////// Buttons //////////////////////////////
    // 일반 채용 button
    void ShowProgressEmploy(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressEmployScreen, true);
        m_ProgressEmployPanel.RemoveFromClassList(k_ProgressInActiveClass);
        m_ProgressEmployPanel.AddToClassList(k_ProgressActiveClass);
        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // 일반 채용 -> 예 button
    void ShowEmployPanel(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressEmployScreen, false);
        m_ProgressEmployPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressEmployPanel.AddToClassList(k_ProgressInActiveClass);

        //ShowVisualElement(m_MainPanel, false);
        //ShowVisualElement(m_EmployPanel, true);

        AkSoundEngine.PostEvent("UI_Loading", gameObject);
    }
    // 일반 채용 -> 아니요 button
    void HideProgressEmploy(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressEmployScreen, false);
        m_ProgressEmployPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressEmployPanel.AddToClassList(k_ProgressInActiveClass);

        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // 스카우트 button
    void ShowProgressScout(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressScoutScreen, true);
        m_ProgressScoutPanel.RemoveFromClassList(k_ProgressInActiveClass);
        m_ProgressScoutPanel.AddToClassList(k_ProgressActiveClass);

        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // 스카우트 -> 예 button
    void ShowScoutPanel(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressScoutScreen, false);
        m_ProgressScoutPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressScoutPanel.AddToClassList(k_ProgressInActiveClass);

        ShowVisualElement(m_MainPanel, false);
        ShowVisualElement(m_ScoutPanel, true);

        AkSoundEngine.PostEvent("UI_Loading", gameObject);
    }
    // 스카우트 -> 아니요 button
    void HideProgressScout(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressScoutScreen, false);
        m_ProgressScoutPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressScoutPanel.AddToClassList(k_ProgressInActiveClass);

        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // 마력풀 button
    void ShowProgressPool(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressPoolScreen, true);
        m_ProgressPoolPanel.RemoveFromClassList(k_ProgressInActiveClass);
        m_ProgressPoolPanel.AddToClassList(k_ProgressActiveClass);

        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // 마력풀 -> 예 button
    void ShowPoolPanel(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressPoolScreen, false);
        m_ProgressPoolPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressPoolPanel.AddToClassList(k_ProgressInActiveClass);

        ShowVisualElement(m_MainPanel, false);
        ShowVisualElement(m_PoolPanel, true);

        AkSoundEngine.PostEvent("UI_Loading", gameObject);
    }
    // 마력풀 -> 아니요 button
    void HideProgressPool(ClickEvent evt)
    {
        ShowVisualElement(m_ProgressPoolScreen, false);
        m_ProgressPoolPanel.RemoveFromClassList(k_ProgressActiveClass);
        m_ProgressPoolPanel.AddToClassList(k_ProgressInActiveClass);

        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }

    public void ShowMainPanel()
    {
        ShowVisualElement(m_MainPanel, true);
        ShowVisualElement(m_EmployPanel, false);
        ShowVisualElement(m_ScoutPanel, false);
        ShowVisualElement(m_PoolPanel, false);
    }
    
    void GetCharacter(ClickEvent evt)
    {
        GetRandomCharacter?.Invoke();
    }
}
