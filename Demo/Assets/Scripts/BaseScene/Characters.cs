using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Characters
{
     public int      id;
     public string   Vil_Name;
     public int      Vil_Grade;
     public int      Range_Normal;
     public int      Range_Escape;
     public int      Vil_Synergy_1;
     public int      Vil_Synergy_2;
     public float    Vil_Cooltime;
     public int      Vil_Hp;
     public int      Vil_Hp_Max;
     public int      Vil_Str;
     public int      Vil_Str_Max;
     public int      Vil_Royalty;
     public int      EduTime = 0;
     public int      BWTime = 0;
     public bool     canPromote = true;
     public int      getNum = 0;
}
