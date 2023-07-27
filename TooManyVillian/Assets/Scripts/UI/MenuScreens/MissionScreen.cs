using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class MissionScreen : MenuScreen
{
    const string k_LocationPanel = "Mission__location";
    const string k_TypePanel = "Mission__type";
    const string k_ListPanel = "Mission__list";
    const string k_SquadPanel = "Mission__squad";

    const string k_LocationToTypeButton = "Mission__location-nextPage";
    const string k_TypeToListButton = "Mission__type-nextPage";
    const string k_ListToSquadButton = "Mission__list-nextPage";
    const string k_SquadToStartButton = "Mission__squad-nextPage";

    VisualElement m_LocationPanel;
    VisualElement m_TypePanel;
    VisualElement m_ListPanel;
    VisualElement m_SquadPanel;

    Button m_LocationToTypeButton;
    Button m_TypeToListButton;
    Button m_ListToSquadButton;
    Button m_SquadToStartButton;

    private void OnEnable()
    {
        ShowLocationPanel();
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_LocationPanel = m_Root.Q<VisualElement>(k_LocationPanel);
        m_TypePanel = m_Root.Q<VisualElement>(k_TypePanel);
        m_ListPanel = m_Root.Q<VisualElement>(k_ListPanel);
        m_SquadPanel = m_Root.Q<VisualElement>(k_SquadPanel);

        m_LocationToTypeButton = m_Root.Q<Button>(k_LocationToTypeButton);
        m_TypeToListButton = m_Root.Q<Button>(k_TypeToListButton);
        m_ListToSquadButton = m_Root.Q<Button>(k_ListToSquadButton);
        m_SquadToStartButton = m_Root.Q<Button>(k_SquadToStartButton);
    }

    protected override void RegisterButtonCallbacks()
    {
       m_LocationToTypeButton?.RegisterCallback<ClickEvent>(ShowTypePanel);
       m_TypeToListButton?.RegisterCallback<ClickEvent>(ShowListPanel);
       m_ListToSquadButton?.RegisterCallback<ClickEvent>(ShowSquadPanel);
       m_SquadToStartButton?.RegisterCallback<ClickEvent>(StartMission);
    }

    void ShowTypePanel(ClickEvent evt)
    {
        ShowVisualElement(m_LocationPanel, false);
        ShowVisualElement(m_TypePanel, true);
    }
    void ShowListPanel(ClickEvent evt)
    {
        ShowVisualElement(m_TypePanel, false);
        ShowVisualElement(m_ListPanel, true);
    }
    void ShowSquadPanel(ClickEvent evt)
    {
        ShowVisualElement(m_ListPanel, false);
        ShowVisualElement(m_SquadPanel, true);
    }
    void StartMission(ClickEvent evt)
    {
        SceneManager.LoadScene("battle");
    }
    public void ShowLocationPanel()
    {
        ShowVisualElement(m_TypePanel, false);
        ShowVisualElement(m_ListPanel, false);
        ShowVisualElement(m_SquadPanel, false);
        ShowVisualElement(m_LocationPanel, true);
    }

}
