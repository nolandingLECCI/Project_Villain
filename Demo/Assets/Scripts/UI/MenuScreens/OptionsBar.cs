using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsBar : MenuScreen
{
    //buttons
    const string k_OptionButton = "topbar__option";
    const string k_HomeButton = "topbar-back_button";

    //label
    const string k_GoldCount = "option-bar__gold-count";
    const string k_DMCount = "option-bar__DM-count";
    const string k_DDCount = "option-bar__DD-count";

    const string k_MenuName = "MenuName";

    //class
    const string k_TopbarDefaultClass = "topbar--active";
    const string k_TopbarHomeClass = "topbar";

    const string k_OptionsDefaultClass = "options-bar--default";
    const string k_OptionsHomeClass = "options-bar--home";

    const float k_LerpTime = 0.6f;

    VisualElement m_OptionButton;
    VisualElement m_HomeButton;

    Label m_GoldLabel;
    Label m_DMLabel;
    Label m_DDLabel;

    Label m_MenuName;

    private void OnEnable()
    {
        GameDataManager.FundsUpdated += OnFundsUpdated;
    }

    private void OnDisable()
    {
        GameDataManager.FundsUpdated -= OnFundsUpdated;
    }

    // identify visual elements by name
    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_OptionButton = m_Root.Q(k_OptionButton);
        m_HomeButton = m_Root.Q(k_HomeButton);

        m_GoldLabel = m_Root.Q<Label>(k_GoldCount);
        m_DMLabel = m_Root.Q<Label>(k_DMCount);
        m_DDLabel = m_Root.Q<Label>(k_DDCount);

        m_MenuName = m_Root.Q<Label>(k_MenuName);
    }

    // set up button click events
    protected override void RegisterButtonCallbacks()
    {
        //m_OptionButton?.RegisterCallback<ClickEvent>(ShowOptionScreen);
        m_HomeButton?.RegisterCallback<ClickEvent>(ShowHomeScreen);
    }

    ///////////////////// Buttons //////////////////////////////
    // setting button
    // void ShowOptionsScreen(ClickEvent evt)
    // {
    //     m_MainMenuUIManager?.ShowSettingsScreen();
    // }
    // home button
    void ShowHomeScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowHomeScreen();
    }
    ///////////////////// fund //////////////////////////////////////
    public void SetGold(uint gold)
    {
        uint startValue = (uint) Int32.Parse(m_GoldLabel.text);
        StartCoroutine(LerpRoutine(m_GoldLabel, startValue, gold, k_LerpTime));
    }

    public void SetDM(uint dm)
    {
        uint startValue = (uint)Int32.Parse(m_DMLabel.text);
        StartCoroutine(LerpRoutine(m_DMLabel, startValue, dm, k_LerpTime));
    }

    public void SetDD(uint dd)
    {
        uint startValue = (uint)Int32.Parse(m_DDLabel.text);
        StartCoroutine(LerpRoutine(m_DDLabel, startValue, dd, k_LerpTime));
    }


    void OnFundsUpdated(GameData gameData)
    {
        SetGold(gameData.gold);
        SetDM(gameData.darkMatter);
        SetDD(gameData.d_day);
    }

    // animated Label counter
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

    public void SetMenuName(string name)
    {
        m_MenuName.text = name;
    }

    public void OnOffTopbar(bool onoff)
    {
        if(onoff)
        {
            OnOffElement(m_MenuName, k_TopbarDefaultClass, k_TopbarHomeClass);
        }
        
    }

    void OnOffElement(VisualElement visualElem, string inactiveClass, string activeClass)
    {
        if (visualElem == null)
            return;

        visualElem.RemoveFromClassList(inactiveClass);
        visualElem.AddToClassList(activeClass);
    }
}
