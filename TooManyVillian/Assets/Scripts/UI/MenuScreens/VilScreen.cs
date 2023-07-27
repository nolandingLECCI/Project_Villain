using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.UIElements;

public class VilScreen : MenuScreen
{
    const string k_CharaListPanel = "character_list-group";

    VisualElement m_CharaListPanel;
    VisualElement m_EmptyCharaListPanel;

    [Header("Character List")]
    [Tooltip("Character List Asset to instantiate ")]
    [SerializeField] VisualTreeAsset m_CharacterPortrait;

    void OnEnable()
    {
        GameDataManager.PoolUpdated += OnPoolUpdated;
    }

    private void OnDisable()
    {
        GameDataManager.PoolUpdated -= OnPoolUpdated;
    }

    void OnPoolUpdated(GameData gameData)
    {
        m_CharaListPanel.Clear();
        CreateCharacterList(gameData.CharaData, m_CharaListPanel);
    }
    void CreateCharacterList(List<CharacterData> charaList, VisualElement parentElement)
    {

        foreach (CharacterData charaData in charaList)
        {
            CreateCharacterPortraitElement(charaData, parentElement);
        }
    }

    void CreateCharacterPortraitElement(CharacterData characterData, VisualElement parentElement)
    {
        if (parentElement == null || characterData == null || m_CharacterPortrait == null)
                return;
        TemplateContainer characterElem = m_CharacterPortrait.Instantiate();

        CharacterPortraitComponent CharacterPortraitController = new CharacterPortraitComponent(characterData);
        CharacterPortraitController.SetVisualElements(characterElem);
        CharacterPortraitController.SetGameData(characterElem);

        parentElement.Add(characterElem);
    }

    protected override void SetVisualElements()
    {
        base.SetVisualElements();
        m_CharaListPanel = m_Root.Q<VisualElement>(k_CharaListPanel);
        m_EmptyCharaListPanel = m_CharaListPanel;
    }
}
