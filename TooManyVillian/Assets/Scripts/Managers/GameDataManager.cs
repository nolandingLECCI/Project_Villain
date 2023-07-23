using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SaveManager))]
public class GameDataManager : MonoBehaviour
{
    // public static event Action<GameData> PotionsUpdated;
    public static event Action<GameData> FundsUpdated;
    public static event Action<GameData> PoolUpdated;
    // public static event Action<ShopItemType, uint, Vector2> RewardProcessed;
    // public static event Action<ShopItemSO, Vector2> TransactionProcessed;
    // public static event Action<ShopItemSO> TransactionFailed;
    // public static event Action<bool> LevelUpButtonEnabled;
    // public static event Action<bool> CharacterLeveledUp;
    // public static event Action<string> HomeMessageShown;

    [SerializeField] GameData m_GameData;
    public GameData GameData { set => m_GameData = value; get => m_GameData; }

    SaveManager m_SaveManager;
    bool m_IsGameDataInitialized;

    void OnEnable()
    {
        //HomeScreen.HomeScreenShown += OnHomeScreenShown;

    //     ShopController.ShopItemPurchasing += OnPurchaseItem;

    //     SettingsScreen.SettingsUpdated += OnSettingsUpdated;
    //     MailController.RewardClaimed += OnRewardClaimed;

    //     CharScreenController.CharacterShown += OnCharacterShown;
    //     CharScreenController.LevelPotionUsed += OnLevelPotionUsed;
    //     SettingsScreen.ResetPlayerFunds += OnResetFunds;
    }

    void OnDisable()
    {
        //HomeScreen.HomeScreenShown -= OnHomeScreenShown;

    //     ShopController.ShopItemPurchasing -= OnPurchaseItem;

    //     SettingsScreen.SettingsUpdated -= OnSettingsUpdated;
    //     MailController.RewardClaimed -= OnRewardClaimed;

    //     CharScreenController.CharacterShown -= OnCharacterShown;
    //     CharScreenController.LevelPotionUsed -= OnLevelPotionUsed;

    //     SettingsScreen.ResetPlayerFunds -= OnResetFunds;
    }
    void Awake()
    {
        m_SaveManager = GetComponent<SaveManager>();
    }

    void Start()
    {
        //if saved data exists, load saved data
        m_SaveManager?.LoadGame();

        // flag that GameData is loaded the first time
        m_IsGameDataInitialized = true;

        UpdateFunds();
        UpdatePool();    
    }

    // transaction methods 
    void UpdateFunds()
    {
        if (m_GameData != null)
            FundsUpdated?.Invoke(m_GameData);
    }
    void UpdatePool()
    {
        if(m_GameData != null)
            PoolUpdated?.Invoke(m_GameData);
    }
    // update values from SettingsScreen
    void OnSettingsUpdated(GameData gameData)
    {

        if (gameData == null)
            return;

        m_GameData.sfxVolume = gameData.sfxVolume;
        m_GameData.musicVolume = gameData.musicVolume;
        m_GameData.theme = gameData.theme;
        m_GameData.username = gameData.username;
    }
    void OnResetFunds()
    {
        m_GameData.gold = 0;
        m_GameData.darkMatter = 0;
        m_GameData.d_day = 99;
        UpdateFunds();
    }

}
