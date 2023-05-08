using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new quest", menuName = "Quest")]
public class Quest : ScriptableObject
{
    public string QuestName;
    public string Description;
    public int RewardGold;
    public int RewardDarkMatter;
}
