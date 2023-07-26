using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class SettingScreen : MenuScreen
{
    public static event Action SettingsShown;
    public static event Action<GameData> SettingsUpdated;

    public static event Action IncreaseGold;
    public static event Action IncreaseDM;
    public static event Action ResetGame;

    // string IDs
    const string k_PanelBackButton = "settings__panel-back-button";

    const string k_IncreaseGoldButton = "settings--Debug_gold";
    const string k_IncreaseDMButton = "settings--Debug_dm";
    const string k_ResetGameButton = "settings--Debug_reset";

    const string k_PanelActiveClass = "settings__panel";
    const string k_PanelInactiveClass = "settings__panel--inactive";

    const string k_SettingsPanel = "settings__panel";

    // visual elements
    VisualElement m_PanelBackButton;

    // root node for transitions
    VisualElement m_Panel;
    // buttons
    Button m_IncreaseGoldButton;
    Button m_IncreaseDMButton;
    Button m_ResetGameButton;

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

        m_IncreaseGoldButton = m_Root.Q<Button>(k_IncreaseGoldButton);
        m_IncreaseDMButton = m_Root.Q<Button>(k_IncreaseDMButton);
        m_ResetGameButton = m_Root.Q<Button>(k_ResetGameButton);
        
        m_Panel = m_Root.Q(k_SettingsPanel);
    }

    protected override void RegisterButtonCallbacks()
    {
        m_PanelBackButton?.RegisterCallback<ClickEvent>(ClosePanel);

        m_IncreaseGoldButton?.RegisterCallback<ClickEvent>(IncreaseGoldValue);
        m_IncreaseDMButton?.RegisterCallback<ClickEvent>(IncreaseDMValue);
        m_ResetGameButton?.RegisterCallback<ClickEvent>(ResetGameData);
    }
    // close button
    void ClosePanel(ClickEvent evt)
    {
        m_Panel.RemoveFromClassList(k_PanelActiveClass);
        m_Panel.AddToClassList(k_PanelInactiveClass);

        SettingsUpdated?.Invoke(m_SettingsData);

        HideScreen();
        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }

    void IncreaseGoldValue(ClickEvent evt)
    {
        IncreaseGold?.Invoke();
    }

    void IncreaseDMValue(ClickEvent evt)
    {
        IncreaseDM?.Invoke();
    }

    void ResetGameData(ClickEvent evt)
    {
        ResetGame?.Invoke();
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