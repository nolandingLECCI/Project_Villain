using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

[RequireComponent(typeof(SaveManager))]
public class GameDataManager : MonoBehaviour
{
    public static event Action<GameData> FundsUpdated;
    public static event Action<GameData> PoolUpdated;

    [SerializeField] GameData m_GameData;
    public GameData GameData { set => m_GameData = value; get => m_GameData; }


    [SerializeField] private GatchaRate[] gatcha;
    [SerializeField] private List<CharacterBaseSO> m_CharaList;
    [SerializeField] private List<CharacterData> m_GatchaReward = new List<CharacterData>();
    [SerializeField] private int GatchaTime = 10;

    SaveManager m_SaveManager;
    bool m_IsGameDataInitialized;

    void OnEnable()
    {
        SortByRarity();
        EmployScreen.GetRandomCharacter += GetRandomCharacters;
    }

    void OnDisable()
    {
        EmployScreen.GetRandomCharacter -= GetRandomCharacters;
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

    void GetRandomCharacters()
    {
        for(int i = 0 ; i< GatchaTime ; i++)
        {
            m_GatchaReward.Add(GetRandomStat(SelectReward()));
        }
        for(int i = 0 ; i < GatchaTime ; i++)
        {
            m_GameData.CharaData.Add(m_GatchaReward[i]);
            //m_GatchaReward.RemoveAt(0);
        }
        UpdatePool();
    }
    CharacterData GetRandomStat(CharacterBaseSO c)
    {
        CharacterData chara = new CharacterData();

        chara.m_id = c.id;
        chara.m_Vil_Name = c.Vil_Name;
        chara.m_characterProfile = c.characterProfile;
        chara.m_characterVisualsPrefab = c.characterVisualsPrefab;

        chara.m_rarity = c.rarity.ToString();
        chara.m_Vil_Synergy = new List<SynergyBaseSO>();
        foreach(SynergyBaseSO s in c.Vil_Synergy)
        {
           chara.m_Vil_Synergy.Add(s);
        }
        chara.m_skill = c.skill;
        chara.m_weapon = c.weapon.ToString();
        chara.m_Vil_Demon = c.Vil_Demon;

        chara.m_Range_Normal = c.Range_Normal;
        chara.m_Range_Escape = c.Range_Escape;
        chara.m_Vil_Cooltime = c.Vil_Cooltime;
        chara.m_Vil_Hp = (uint)Random.Range(c.Vil_Hp_Min, c.Vil_Hp_Max);
        chara.m_Vil_Hp_Potential = (float)chara.m_Vil_Hp/(float)c.Vil_Hp_Max;
        chara.m_Vil_Str = (uint)Random.Range(c.Vil_Str_Min, c.Vil_Str_Max);
        chara.m_Vil_Str_Potential = (float)chara.m_Vil_Str/(float)c.Vil_Str_Max;
        chara.m_Vil_Loyalty = c.Vil_Loyalty;

        return chara;
    }
    CharacterBaseSO SelectReward()
    {
        int total = 0;
        Rarity rarity = gatcha[0].rarity;
        foreach(GatchaRate g in gatcha)
        {
            total += g.rate;
        }
        int rnd = Random.Range(1 , total);
        foreach(GatchaRate g in gatcha)
        {
            if(rnd <= g.rate)
            {
                rarity = g.rarity;
                break;
            }
            else
                rnd -= g.rate;
        }

        GatchaRate gr = Array.Find(gatcha, rt => rt.rarity == rarity);
        List<CharacterBaseSO> reward = gr.reward;
        rnd = Random.Range(0,reward.Count);
        return reward[rnd];
    }
    void SortByRarity()
    {
        foreach(CharacterBaseSO b in m_CharaList)
        {
            foreach(GatchaRate g in gatcha)
            {
                if(b.rarity == g.rarity)
                {
                    g.reward.Add(b);
                }
            }
        }
    }

}
