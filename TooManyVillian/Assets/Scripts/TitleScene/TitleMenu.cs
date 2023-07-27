using System;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleMenu : MenuScreen
{
    const string k_newGame = "newgame";

    Button m_newGame;

    protected override void SetVisualElements()
    {
        base.SetVisualElements();

        m_newGame = m_Root.Q<Button>(k_newGame);
    }
    protected override void RegisterButtonCallbacks()
    {
       m_newGame?.RegisterCallback<ClickEvent>(StartNewGame);
    }

    void StartNewGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Main");
    }   
}

