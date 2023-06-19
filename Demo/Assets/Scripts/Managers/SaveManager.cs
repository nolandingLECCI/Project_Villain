using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using System;

[RequireComponent(typeof(GameDataManager))]
public class SaveManager : MonoBehaviour
{
    GameDataManager m_GameDataManager;
    [SerializeField] string m_SaveFilename = "savegame.dat";

    void Awake()
    {
        m_GameDataManager = GetComponent<GameDataManager>();
    }
    void OnApplicationQuit()
        {
            SaveGame();
        }

        // void OnEnable()
        // {
        //     SettingsScreen.SettingsShown += OnSettingsShown;
        //     SettingsScreen.SettingsUpdated += OnSettingsUpdated;

        //     GameScreenController.SettingsUpdated += OnSettingsUpdated;

        // }

        // void OnDisable()
        // {
        //     SettingsScreen.SettingsShown -= OnSettingsShown;
        //     SettingsScreen.SettingsUpdated -= OnSettingsUpdated;

        //     GameScreenController.SettingsUpdated -= OnSettingsUpdated;

        // }
        public GameData NewGame()
        {
            return new GameData();
        }

        public void LoadGame()
        {
            // load saved data from FileDataHandler

            // if (m_GameDataManager.GameData == null)
            // {
            //     if (m_DebugValues)
            //     {
            //         Debug.Log("GAME DATA MANAGER LoadGame: Initializing game data.");
            //     }
                
            //     m_GameDataManager.GameData = NewGame();
            // }
            // else if (FileManager.LoadFromFile(m_SaveFilename, out var jsonString))
            // {
            //     m_GameDataManager.GameData.LoadJson(jsonString);

            //     if (m_DebugValues)
            //     {
            //         Debug.Log("SaveManager.LoadGame: " + m_SaveFilename + " json string: " + jsonString);
            //     }
            // }

            // notify other game objects 
            // if (m_GameDataManager.GameData != null)
            // {
            //     GameDataLoaded?.Invoke(m_GameDataManager.GameData);
            // }
        }

        public void SaveGame()
        {
            string jsonFile = m_GameDataManager.GameData.ToJson();

            // save to disk with FileDataHandler
            // if (FileManager.WriteToFile(m_SaveFilename, jsonFile) && m_DebugValues)
            // {
            //     Debug.Log("SaveManager.SaveGame: " + m_SaveFilename + " json string: " + jsonFile);
            // }
        }

        // void OnSettingsShown()
        // {
        //     // pass the GameData to the Settings Screen
        //     if (m_GameDataManager.GameData != null)
        //     {
        //         GameDataLoaded?.Invoke(m_GameDataManager.GameData);
        //     }
        // }

        void OnSettingsUpdated(GameData gameData)
        {
            m_GameDataManager.GameData = gameData;
            SaveGame();
        }
    }
