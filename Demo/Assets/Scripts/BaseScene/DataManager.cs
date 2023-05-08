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


    [SerializeField] private int InitialGold;
    [SerializeField] private int InitialDarkMatter;
    

    private void Start() {
        Init();
    }

    void Init()
    {
        gold = InitialGold;
        darkMatter = InitialDarkMatter;
        CharacterPool = new List<Characters>();
        Quests = new List<Quest>();
    }
}
