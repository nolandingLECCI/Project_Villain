using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class HomeScreen : MenuScreen
{
    public static event Action PlayButtonClicked;
    public static event Action HomeScreenShown;

    const string k_ShopScreenMenuButton = "menu__shop-button";
    const string k_VilScreenMenuButton = "menu__vil-button";
    const string k_EducationScreenMenuButton = "menu__education-button";
    const string k_EmployScreenMenuButton = "menu__employ-button";
    const string k_QuestScreenMenuButton = "menu__quest-button";

    const string k_MissionScreenMenuButton = "home-play__level-button";

    Button m_ShopScreenMenuButton;
    Button m_VilScreenMenuButton;
    Button m_EducationScreenMenuButton;
    Button m_EmployScreenMenuButton;
    Button m_QuestScreenMenuButton;

    Button m_MissionScreenMenuButton;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_ShopScreenMenuButton = m_Root.Q<Button>(k_ShopScreenMenuButton);
        m_VilScreenMenuButton = m_Root.Q<Button>(k_VilScreenMenuButton);
        m_EducationScreenMenuButton = m_Root.Q<Button>(k_EducationScreenMenuButton);
        m_EmployScreenMenuButton = m_Root.Q<Button>(k_EmployScreenMenuButton);
        m_QuestScreenMenuButton = m_Root.Q<Button>(k_QuestScreenMenuButton);
        m_MissionScreenMenuButton = m_Root.Q<Button>(k_MissionScreenMenuButton);

    }

    protected override void RegisterButtonCallbacks()
    {
        base.RegisterButtonCallbacks();

        m_ShopScreenMenuButton?.RegisterCallback<ClickEvent>(ShowShopScreen);
        m_VilScreenMenuButton?.RegisterCallback<ClickEvent>(ShowVilScreen);
        m_EducationScreenMenuButton?.RegisterCallback<ClickEvent>(ShowEducationScreen);
        m_EmployScreenMenuButton?.RegisterCallback<ClickEvent>(ShowEmployScreen);
        m_QuestScreenMenuButton?.RegisterCallback<ClickEvent>(ShowQuestScreen);
        m_MissionScreenMenuButton?.RegisterCallback<ClickEvent>(ShowMissionScreen);

    }

    void ShowShopScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowShopScreen();
    }
    void ShowVilScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowVilScreen();
    }
    void ShowEducationScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowEducationScreen();
    }
    void ShowEmployScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowEmployScreen();
    }
    void ShowQuestScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowQuestScreen();
    }
    void ShowMissionScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowMissionScreen();
    }

    public override void ShowScreen()
    {
        base.ShowScreen();
        HomeScreenShown?.Invoke();
    }
}
