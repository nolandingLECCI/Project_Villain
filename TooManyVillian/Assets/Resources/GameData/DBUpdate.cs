using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DBUpdate : MonoBehaviour
{
    [SerializeField] private DB villianDB;
    [SerializeField] private List<CharacterBaseSO> CharaGO;
    [SerializeField] private List<SkillBaseSO> SkillGO;
    [SerializeField] private List<SynergyBaseSO> SynergyGO;
    [SerializeField] private List<GameObject> Effects;

    [SerializeField] private List<Sprite> ProfileImages;
    [SerializeField] private List<Sprite> ProfileImages_battle;

    [SerializeField] string m_ResourcePath = "GameData";
    // void Awake()
    // {

    // }

    void Start()
    {
        LoadData();
        UpdateDB();
    }
    private void UpdateDB()
    {
        UpdateSkill();
        UpdateChara();
    }
    private void UpdateSkill()
    {
        int i = 0;
        foreach(SkillBaseSO GO in SkillGO)
        {
            GO.Skill_Name = villianDB.Skill[i].Skill_Name;
            GO.Skill_Bio = villianDB.Skill[i].Skill_Bio;
            GO.Skill_Cooltime = villianDB.Skill[i].Skill_Cooltime;

            foreach(GameObject fx in Effects)
            {
                if(fx.name == villianDB.Skill[i].Skill_Effect)
                {
                    GO.Skill_Effect = fx;;
                    break;
                }
            }
            i++;
        }
    }
    private void UpdateChara()
    {
        int i = 0;
        foreach(CharacterBaseSO GO in CharaGO)
        {
            //////////////// Set Stat ///////////////////////
            GO.id = (uint)i;
            GO.Vil_Name = villianDB.Villian[i].Vil_Name;
            GO.Vil_Demon = villianDB.Villian[i].Vil_Demon;
            GO.Range_Normal = villianDB.Villian[i].Range_Normal;
            GO.Range_Escape = villianDB.Villian[i].Range_Escape;
            GO.Vil_Cooltime = villianDB.Villian[i].Vil_Cooltime;
            GO.Vil_Hp_Min = villianDB.Villian[i].Vil_Hp_Min;
            GO.Vil_Hp_Max = villianDB.Villian[i].Vil_Hp_Max;
            GO.Vil_Str_Min = villianDB.Villian[i].Vil_Str_Min;
            GO.Vil_Str_Max = villianDB.Villian[i].Vil_Str_Max;
            GO.Vil_Loyalty = villianDB.Villian[i].Vil_Loyalty;
            ///////////////// Set Rarity ////////////////////
            if(villianDB.Villian[i].Vil_Rarity == "Common")
                GO.rarity = Rarity.Common;
            if(villianDB.Villian[i].Vil_Rarity == "Rare")
                GO.rarity = Rarity.Rare;
            if(villianDB.Villian[i].Vil_Rarity == "Epic")
                GO.rarity = Rarity.Epic;
            //////////////// Set Weapon ///////////////////
            if(villianDB.Villian[i].Vil_Weapon == "LongSword")
                GO.weapon = Weapon.LongSword;
            if(villianDB.Villian[i].Vil_Weapon == "Dagger")
                GO.weapon = Weapon.Dagger;
            if(villianDB.Villian[i].Vil_Weapon == "Spear")
                GO.weapon = Weapon.Spear;
            if(villianDB.Villian[i].Vil_Weapon == "Gun")
                GO.weapon = Weapon.Gun;
            if(villianDB.Villian[i].Vil_Weapon == "Club")
                GO.weapon = Weapon.Club;
            ////////////////// Set Skill ///////////////////////
            foreach(SkillBaseSO s in SkillGO)
            {
                if(villianDB.Villian[i].Vil_Skill == s.Skill_Name)
                {
                    GO.skill = s;
                    break;
                }
                    
            }
            ////////////////// Set Synergy /////////////////////
            
            foreach(SynergyBaseSO s in SynergyGO)
            {
                if(villianDB.Villian[i].Vil_Synergy_1 == s.Synergy_Name)
                {
                    GO.Vil_Synergy_1 = s;
                }
                if(villianDB.Villian[i].Vil_Synergy_2 == s.Synergy_Name)
                {
                    GO.Vil_Synergy_2 = s;
                }
                if(s.Synergy_Name == null)
                {
                    if(villianDB.Villian[i].Vil_Synergy_1 == null)
                    {
                        GO.Vil_Synergy_1 = s;
                    }
                    if(villianDB.Villian[i].Vil_Synergy_2 == null)
                    {
                        GO.Vil_Synergy_2 = s;
                    }
                }
            }
            //////////////////////// Set Image /////////////////////
            GO.characterProfile = ProfileImages[i];
            GO.characterProfile_Battle = ProfileImages_battle[i];

            i++;
        }
    }

    private void LoadData()
    {
        CharaGO = new List<CharacterBaseSO>();
        SkillGO = new List<SkillBaseSO>();
        SynergyGO = new List<SynergyBaseSO>();

        ProfileImages = new List<Sprite>();
        ProfileImages_battle = new List<Sprite>();

        CharaGO.AddRange(Resources.LoadAll<CharacterBaseSO>(m_ResourcePath+"/Characters"));
        SkillGO.AddRange(Resources.LoadAll<SkillBaseSO>(m_ResourcePath+"/Skills"));
        SynergyGO.AddRange(Resources.LoadAll<SynergyBaseSO>(m_ResourcePath+"/Synergys"));

        ProfileImages.AddRange(Resources.LoadAll<Sprite>(m_ResourcePath+"/Profile"));
        ProfileImages_battle.AddRange(Resources.LoadAll<Sprite>(m_ResourcePath+"/Profile_battle"));
    }
}
