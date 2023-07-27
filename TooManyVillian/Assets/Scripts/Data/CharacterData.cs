using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;
using static UnityEngine.Random;

[System.Serializable]
public class CharacterData
{
    //기본 캐릭터 데이터
     
    public uint                    m_id;
    public string                  m_Vil_Name;
    public Sprite                  m_characterProfile;
    public GameObject              m_characterVisualsPrefab;

    public string                  m_rarity;
    public SynergyBaseSO           m_Vil_Synergy_1;
    public SynergyBaseSO           m_Vil_Synergy_2;
    public SkillBaseSO             m_skill;
    public string                  m_weapon;
    public bool                    m_Vil_Demon;

    
    public uint                    m_Range_Normal;
    public uint                    m_Range_Escape;
    public float                   m_Vil_Cooltime;
    public uint                    m_Vil_Hp;
    public uint                   m_Vil_Hp_Max;
    public uint                    m_Vil_Str;
    public uint                   m_Vil_Str_Max;
    public uint                    m_Vil_Loyalty;

    //강화 관련 변수
    public uint m_TimeEducated;
    public uint m_TimeBrainwashed;
    public bool m_canPromote;
    // 획득 순서
    public uint m_OrderObtained;

    public CharacterData()
    {
        this.m_id = 999;
        this.m_Vil_Name = null;
        this.m_characterProfile = null;
        this.m_characterVisualsPrefab = null;

        this.m_rarity = null;
        this.m_skill  = null;
        this.m_weapon = null;
        this.m_Vil_Demon = false;

        this.m_Range_Normal = 0;
        this.m_Range_Escape = 0;
        this.m_Vil_Cooltime = 0;
        this.m_Vil_Hp = 0;
        this.m_Vil_Hp_Max = 0;
        this.m_Vil_Str = 0;
        this.m_Vil_Str_Max =0;
        this.m_Vil_Loyalty = 50;

        this.m_TimeEducated = 0;
        this.m_TimeBrainwashed = 0;
        this.m_canPromote = true;

        this.m_OrderObtained = 0;
    }
}
