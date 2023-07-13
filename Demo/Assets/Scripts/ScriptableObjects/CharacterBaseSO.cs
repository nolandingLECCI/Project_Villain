using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum Rarity
{
    Common,
    Rare,
    Epic,
    Demon,
}
// public enum Synergy
// {
//     None,
//     Ace,
//     Interest,
//     Newbie,
//     NightVil,
//     Saibi,
//     Vampire,
// }
public enum Weapon
{
    LongSword,
    Dagger,
    Spear,
    Gun,
}


[CreateAssetMenu(fileName ="Assets/Resources/GameData/Characters/CharacterGameData", menuName = "vil/Character", order = 1)]
    public class CharacterBaseSO : ScriptableObject
    {
        [Header("Desciption")]
        public uint id;
        public string Vil_Name;
        public Sprite characterProfile;
        public GameObject characterVisualsPrefab;

        [Header("Data")]
        public Rarity rarity;
        public List<SynergyBaseSO> Vil_Synergy;
        public SkillBaseSO skill;
        public Weapon weapon;
        public bool Vil_Demon;

        [Header("Stats")]
        public uint     Range_Normal;
        public uint     Range_Escape;
        public float    Vil_Cooltime;
        public uint     Vil_Hp_Min;
        public uint     Vil_Hp_Max;
        public uint     Vil_Str_Min;
        public uint     Vil_Str_Max;
        public uint     Vil_Loyalty;
    }   

