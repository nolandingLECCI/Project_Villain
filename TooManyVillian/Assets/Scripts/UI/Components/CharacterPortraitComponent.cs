using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterPortraitComponent
{
    //public static event Action<> CharacterClicked;

    
    const string k_ParentContainer = "CharPortrait__parent-container";
    //visual element
    const string k_ProfileImage = "CharPortrait__profile_image";

    const string k_HpBar = "CharPortrait__data-health_board";
    const string k_StrBar = "CharPortrait__data-strength_board";
    const string k_LoyaltyBar = "CharPortrait__data-loyalty_board";
    const string k_RarityBar = "CharPortrait__data-grade_board";

    //labels
    const string k_CharaName = "CharPortrait__data-name";
    const string k_RarityLabel = "CharPortrait__data-grade_text";
    const string k_Synergy1Label = "CharPortrait__data-synergy1_text";
    const string k_Synergy2Label = "CharPortrait__data-synergy2_textt";
    const string k_HpLabel = "CharPortrait__data-health_text";
    const string k_StrLabel = "CharPortrait__data-strength_text";
    const string k_LoyaltyLabel = "CharPortrait__data-loyalty_text";

    //class
    const string k_CommonClass = "rarity--common";
    const string k_RareClass = "rarity--rare";
    const string k_EpicClass = "rarity--epic";
    const string k_DemonClass = "rarity--demon";


    CharacterData m_CharaData;

    VisualElement m_ParentContainer;

    VisualElement m_profileImage;

    VisualElement m_HpBar;
    VisualElement m_StrBar;
    VisualElement m_LoyaltyBar;
    VisualElement m_RarityBar;

    Label m_CharaName;
    Label m_RarityLabel;
    Label m_Synergy1Label;
    Label m_Synergy2Label;
    Label m_HpLabel;
    Label m_StrLabel;
    Label m_LoyaltyLabel;

    public CharacterPortraitComponent(CharacterData charaData)
    {
        m_CharaData = charaData;
    }

    public void SetVisualElements(TemplateContainer characterPortraitElement)
    {
        m_ParentContainer = characterPortraitElement.Q<VisualElement>(k_ParentContainer);

        m_profileImage = characterPortraitElement.Q<VisualElement>(k_ProfileImage);

        m_HpBar = characterPortraitElement.Q<VisualElement>(k_HpBar);
        m_StrBar = characterPortraitElement.Q<VisualElement>(k_StrBar);
        m_LoyaltyBar = characterPortraitElement.Q<VisualElement>(k_LoyaltyBar);
        m_RarityBar = characterPortraitElement.Q<VisualElement>(k_RarityBar);

        m_CharaName = characterPortraitElement.Q<Label>(k_CharaName);
        m_RarityLabel = characterPortraitElement.Q<Label>(k_RarityLabel);
        m_Synergy1Label = characterPortraitElement.Q<Label>(k_Synergy1Label);
        m_Synergy2Label = characterPortraitElement.Q<Label>(k_Synergy2Label);
        m_HpLabel = characterPortraitElement.Q<Label>(k_HpLabel);
        m_StrLabel = characterPortraitElement.Q<Label>(k_StrLabel);
        m_LoyaltyLabel = characterPortraitElement.Q<Label>(k_LoyaltyLabel);
    }
    public void SetGameData(TemplateContainer characterPortraitElement)
    {
        if (characterPortraitElement == null)
            return;

        m_profileImage.style.backgroundImage = new StyleBackground(m_CharaData.m_characterProfile);

        m_HpBar.style.width = Length.Percent((float)m_CharaData.m_Vil_Hp/(float)m_CharaData.m_Vil_Hp_Max*100);
        m_StrBar.style.width = Length.Percent((float)m_CharaData.m_Vil_Str/(float)m_CharaData.m_Vil_Str_Max*100);
        m_LoyaltyBar.style.width = Length.Percent((float)m_CharaData.m_Vil_Loyalty);

        m_CharaName.text = m_CharaData.m_Vil_Name;
        switch (m_CharaData.m_rarity)
        {
            case "Common":
                m_RarityLabel.text = "커먼";
                m_RarityBar.AddToClassList(k_CommonClass);
                break;
            case "Rare":
                m_RarityLabel.text = "레어";
                m_RarityBar.AddToClassList(k_RareClass);
                break;
            case "Epic":
                m_RarityLabel.text = "에픽";
                m_RarityBar.AddToClassList(k_EpicClass);
                break;
            case "Demon":
                m_RarityLabel.text = "데몬";
                m_RarityBar.AddToClassList(k_DemonClass);
                break;
        }

        m_Synergy1Label.text = m_CharaData.m_Vil_Synergy[0].Synergy_Name;
        // if(m_CharaData.m_Vil_Synergy.Count == 2)
        //     m_Synergy2Label.text = m_CharaData.m_Vil_Synergy[1].Synergy_Name;
        // else
        //     m_Synergy2Label.text = "";
        
        m_HpLabel.text = m_CharaData.m_Vil_Hp.ToString();
        m_StrLabel.text = m_CharaData.m_Vil_Str.ToString();
        m_LoyaltyLabel.text = m_CharaData.m_Vil_Loyalty.ToString();
        
    }

}
