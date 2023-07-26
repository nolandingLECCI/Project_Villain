using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsBar : MenuScreen
{
    //buttons
    const string k_OptionButton = "topbar__option";

    //label
    const string k_GoldCount = "option-bar__gold-count";
    const string k_DMCount = "option-bar__DM-count";
    const string k_DDCount = "option-bar__DD-count";

    const string k_MenuName = "MenuName";
    //VisualElement
    const string k_OptionsBar = "options-bar";

    //class
    const string k_OptionsbarDefaultClass = "options-bar--default";
    const string k_OptionsbarHomeClass = "options-bar--home";

    const float k_LerpTime = 0.6f;

    Button m_OptionButton;

    VisualElement m_OptionsBar;

    Label m_GoldLabel;
    Label m_DMLabel;
    Label m_DDLabel;

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

        m_OptionButton = m_Root.Q<Button>(k_OptionButton);

        m_OptionsBar = m_Root.Q(k_OptionsBar);

        m_GoldLabel = m_Root.Q<Label>(k_GoldCount);
        m_DMLabel = m_Root.Q<Label>(k_DMCount);
        m_DDLabel = m_Root.Q<Label>(k_DDCount);

    }

    // set up button click events
    protected override void RegisterButtonCallbacks()
    {
        m_OptionButton?.RegisterCallback<ClickEvent>(ShowSettingScreen);
    }

    ///////////////////// Buttons //////////////////////////////
    // setting button
    void ShowSettingScreen(ClickEvent evt)
    {
        m_MainMenuUIManager?.ShowSettingsScreen();
        AkSoundEngine.PostEvent("UI_Select", gameObject);
    }
    // home button
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

    public void OptionsBarAtHome(bool onoff)
    {
        if(onoff)
        {
            m_OptionsBar.RemoveFromClassList(k_OptionsbarDefaultClass);
            m_OptionsBar.AddToClassList(k_OptionsbarHomeClass);
        }
        else
        {
            m_OptionsBar.RemoveFromClassList(k_OptionsbarHomeClass);
            m_OptionsBar.AddToClassList(k_OptionsbarDefaultClass);
        }
    }
        
}
