using System;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterListComponent
{
    const string k_ListContainer = "character_list-group";

    public VisualElement m_ListContainer;

    public void SetVisualElements(TemplateContainer characterListElement)
    {
        m_ListContainer = characterListElement.Q<VisualElement>(k_ListContainer);
    }
}
