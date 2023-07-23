using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SettingScreen : MenuScreen
{
    //public static event Action ResetPlayerFunds;
    //public static event Action ResetPlayerLevel;

    public static event Action SettingsShown;
    public static event Action<GameData> SettingsUpdated;

    // string IDs
    const string k_PanelBackButton = "settings__panel-back-button";

    const string k_PanelActiveClass = "settings__panel";
    const string k_PanelInactiveClass = "settings__panel--inactive";

    const string k_SettingsPanel = "settings__panel";

    // visual elements
    VisualElement m_PanelBackButton;

    // root node for transitions
    VisualElement m_Panel;

    // temp storage to send back to GameDataManager
    GameData m_SettingsData;

    void OnEnable()
    {
        // sets m_SettingsData
        SaveManager.GameDataLoaded += OnGameDataLoaded;
    }

    void OnDisable()
    {
        SaveManager.GameDataLoaded -= OnGameDataLoaded;
    }
    public override void ShowScreen()
    {
        base.ShowScreen();

        // add active style
        m_Panel.RemoveFromClassList(k_PanelInactiveClass);
        m_Panel.AddToClassList(k_PanelActiveClass);

        // notify GameDataManager
        SettingsShown?.Invoke();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_PanelBackButton = m_Root.Q(k_PanelBackButton);
        
        m_Panel = m_Root.Q(k_SettingsPanel);
    }

    protected override void RegisterButtonCallbacks()
    {
        m_PanelBackButton?.RegisterCallback<ClickEvent>(ClosePanel);
    }
    // close button
    void ClosePanel(ClickEvent evt)
    {
        m_Panel.RemoveFromClassList(k_PanelActiveClass);
        m_Panel.AddToClassList(k_PanelInactiveClass);

        SettingsUpdated?.Invoke(m_SettingsData);

        HideScreen();
    }


    // syncs saved data from the GameDataManager to the UI elements
    void OnGameDataLoaded(GameData gameData)
    {
        if (gameData == null)
            return;

        m_SettingsData = gameData;

        SettingsUpdated?.Invoke(m_SettingsData);
    }
}