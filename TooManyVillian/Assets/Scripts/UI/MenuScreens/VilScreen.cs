using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class VilScreen : MenuScreen
{
    const string k_CharacterListPanel = "villian-character_list-panel";

    [Header("Character List")]
    [Tooltip("Character List Asset to instantiate ")]
    [SerializeField] VisualTreeAsset m_CharaListContainer;
    [SerializeField] VisualTreeAsset m_CharacterPortrait;

    VisualElement m_CharacterListPanel;


    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_CharacterListPanel = m_Root.Q<VisualElement>(k_CharacterListPanel);
    }
    void CreateCharacterListElememt(VisualElement parentElement)
    {
        
    }
    void CreateCharacterPortraitElement(CharacterData characterData, VisualElement parentElement)
    {
        if (parentElement == null || characterData == null || m_CharacterPortrait == null)
                return;
        TemplateContainer characterElem = m_CharacterPortrait.Instantiate();

    }
}
