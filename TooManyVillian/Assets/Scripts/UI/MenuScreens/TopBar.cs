using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class TopBar : MenuScreen
{
    //buttons
    const string k_HomeButton = "Topbar-HomeButton";
    //labels
    const string k_MenuName = "Topbar-MenuName";

    VisualElement m_HomeButton;

    Label m_MenuName;

    
    // identify visual elements by name
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_HomeButton = m_Root.Q(k_HomeButton);

        m_MenuName = m_Root.Q<Label>(k_MenuName);
    }

    // set up button click events
    protected override void RegisterButtonCallbacks()
    {
        m_HomeButton?.RegisterCallback<ClickEvent>(ShowHomeScreen);
    }

    ///////////////////// Buttons //////////////////////////////
    // option button
    void ShowOptionsScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowHomeScreen();
        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    //home button
    void ShowHomeScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowHomeScreen();
        AkSoundEngine.PostEvent("UI_Select", gameObject);

    }
    
    public void SetMenuName(string name)
    {
        m_MenuName.text = name;
    }    
}
