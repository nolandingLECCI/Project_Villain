using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Rarity
{
    Common,
    Rare,
    Epic,
}
public enum Synergy
{
    None,
    Ace,
    Interest,
    Newbie,
    NightVil,
    Saibi,
    Vampire,
}

[CreateAssetMenu(fileName ="Assets/Resources/GameData/Characters/CharacterGameData", menuName = "vil/Character", order = 1)]
    public class CharacterBaseSO : ScriptableObject
    {
        public int id;
        public string Vil_Name;
        public GameObject characterVisualsPrefab;
        public Rarity rarity;
        public Synergy Vil_Synergy_1;
        public Synergy Vil_Synergy_2;

        public int      Range_Normal;
        public int      Range_Escape;
        public float    Vil_Cooltime;
        public int      Vil_Hp_Min;
        public int      Vil_Str_Min;

        public bool Vil_Demon;
}   

