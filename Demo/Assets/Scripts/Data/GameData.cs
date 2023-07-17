using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;
using System.Collections.Generic;

[SerializeField]
public class GameData
{
    //메뉴바 표시 항목
    public uint gold;
    public uint darkMatter;
    public uint d_day;

    //캐릭터 풀
    public List<CharacterData> CharaData;
    //캐릭터 수용치
    public uint CharaCap;

    public string username;
    public string theme;

    public float musicVolume;
    public float sfxVolume;

    //초기값
    public GameData()
    {
        this.gold = 500;
        this.darkMatter = 50;
        this.d_day = 99;

        this.CharaData = new List<CharacterData>();
        this.CharaCap  = 20;
        
        this.username = "빌런";
        this.theme = "Default";

        this.musicVolume = 80f;
        this.sfxVolume = 80f;

    }
    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
     public void LoadJson(string jsonFilepath)
    {
        JsonUtility.FromJsonOverwrite(jsonFilepath, this);
    }
}
