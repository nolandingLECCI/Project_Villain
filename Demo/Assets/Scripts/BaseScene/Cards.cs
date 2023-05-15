using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Cards : MonoBehaviour
{
    public CardInfo card;
    public VillianDB DB;

    [SerializeField] public Image img;
    [SerializeField] private TextMeshProUGUI name;
    

    public Image frame;

    
    void Start()
    {
        InitCharaInfo();
        if(card != null)
        {
            img.sprite = card.profile_image;
            name.text = card.characters.Vil_Name;
        }
        
    }
    void UpdateCardInfo()
    {
        //card.UpdateUniqueData();
    }
    public void InitCharaInfo()
    {
        card.characters.id = card.id;
        card.characters.Vil_Name = DB.Villian[card.id].Vil_Name;
        card.characters.Vil_Grade = DB.Villian[card.id].Vil_Grade;
        card.characters.Range_Normal = DB.Villian[card.id].Range_Normal;
        card.characters.Range_Escape = DB.Villian[card.id].Range_Escape;
        card.characters.Vil_Synergy_1 = DB.Villian[card.id].Vil_Synergy_1;
        card.characters.Vil_Synergy_2 = DB.Villian[card.id].Vil_Synergy_2;
        card.characters.Vil_Cooltime = DB.Villian[card.id].Vil_Cooltime;
        card.characters.Vil_Hp_Max = DB.Villian[card.id].Vil_Hp_Max;
        card.characters.Vil_Str_Max = DB.Villian[card.id].Vil_Str_Max;
        card.characters.Vil_Royalty = DB.Villian[card.id].Vil_Royalty;
    }
    public void UpdateUniqueData()
    {
        card.characters.Vil_Hp = Random.Range( DB.Villian[card.id].Vil_Hp_Min, DB.Villian[card.id].Vil_Hp_Max);
        card.characters.Vil_Str = Random.Range( DB.Villian[card.id].Vil_Str_Min, DB.Villian[card.id].Vil_Str_Max);
        //card.characters.getNum = getNum;
    }

    
}
