using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public List<Characters> CharacterPool;
    public int gold;
    public int darkMatter;
    public int poolSize = 20;
    public List<Quest> Quests;
    public int Dday;

    public int population;

    [SerializeField] private int InitialGold;
    [SerializeField] private int InitialDarkMatter;
    

    private void Start() {
        Init();
    }

    private void Init()
    {
        gold = InitialGold;
        darkMatter = InitialDarkMatter;
        CharacterPool = new List<Characters>();
        Quests = new List<Quest>();
    }
    private void UpdateData()
    {
        population = CharacterPool.Count;
    }

    public void SortListByHp()
    {
        CharacterPool.Sort(CompareHp);
    }
    private int CompareHp(Characters a , Characters b)
    {
        if (a.Vil_Hp < b.Vil_Hp)
            return 1;
        else if (a.Vil_Hp < b.Vil_Hp)
            return -1;
        else
            return 0;
    }
}
