using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Assets/Resources/GameData/Synergys/SynergyData", menuName = "vil/Synergy", order = 1)]
public class SynergyBaseSO : ScriptableObject
{
    public string Synergy_Name;
    public Sprite Synergy_Icon;
    public SynergyBaseSO()
    {
        this.Synergy_Name = null;
        this.Synergy_Icon = null;
    }
}   

