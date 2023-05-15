using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Promotion : MonoBehaviour
{
    public Characters chara;
    public DataManager data;

    private const int InitialEdCost_gold = 8000;
    private const int InitialBWCost_gold = 7000;
    private const int InitialBWCost_darkMatter = 10;

    [SerializeField] private int EdCost_gold;
    [SerializeField] private int BWCost_gold;
    [SerializeField] private int BWCost_darkMatter;


    [SerializeField]private float costAdj=1;
    
    public void Education()
    {
        Init();
        if(data.gold < EdCost_gold)
        {
            Debug.Log("교육 비용 부족");
        }
        else
        {
            data.gold -= EdCost_gold;
            chara.Vil_Hp  = (int)(chara.Vil_Hp*1.1f);
            chara.Vil_Str = (int)(chara.Vil_Str*1.1f);
            chara.EduTime++;
        }
    }
    public void Brainwash()
    {
        Init();
        if(data.gold < BWCost_gold || data.darkMatter < BWCost_darkMatter)
        {
            Debug.Log("세뇌 비용 부족");
        }
        else
        {
            data.gold -= BWCost_gold;
            data.darkMatter -= BWCost_darkMatter;
            if(Random.Range(1,5) == 1)
            {
                Debug.Log("20% 확률 걸림");
            }
            chara.BWTime++;
            chara.Vil_Royalty += 30;
            if(chara.Vil_Royalty > 100)
                 chara.Vil_Royalty = 100;
        }
    }
    public void enlighten()
    {
        
    }

    // public void addCharacter(Characters character)
    // {
    //     chara.add(character);
    // }
    // public void removeCharacter(Characters character)
    // {
    //     chara.remove(character);
    // }

    private void Init()
    {
        costAdj=1;
        calcAdj();
        EdCost_gold = (int)(InitialEdCost_gold*costAdj);
        BWCost_gold = (int)(InitialBWCost_gold*costAdj);
        BWCost_darkMatter = (int)(BWCost_darkMatter*costAdj);
    }
    private void calcAdj()
    {
        for(int i = 0 ; i < chara.EduTime ; i++)
        {
            costAdj*=1.4f;
        }
        for(int i = 0 ; i < chara.BWTime ; i++)
        {
            costAdj*=0.7f;
        }
    }
}
