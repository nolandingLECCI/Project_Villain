using UnityEngine;
using UnityEngine.UIElements;

[SerializeField]
public class GameData
{
    public uint gold = 500;
    public uint darkMatter = 50;

    public string username;
    public string theme;

    public float musicVolume;
    public float sfxVolume;

    //초기값
    public GameData()
    {
        this.gold = 500;
        this.darkMatter = 50;
        
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
