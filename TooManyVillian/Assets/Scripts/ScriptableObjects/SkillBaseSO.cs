using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Assets/Resources/GameData/Skills/SkillData", menuName = "vil/Skill", order = 1)]
public class SkillBaseSO : ScriptableObject
{
    public string Skill_Name;
    public string Skill_Bio;
    public float Skill_Cooltime;

    public GameObject Skill_Effect;
    public Sprite SKill_Icon;
}   

