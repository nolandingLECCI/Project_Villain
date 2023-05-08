using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MainUI : MonoBehaviour
{
    [SerializeField] private Image BG;
    [SerializeField] private TextMeshProUGUI GoldAmount;
    [SerializeField] private TextMeshProUGUI DarkMatterAmount;

    [SerializeField] public DataManager Data;

    public List<Sprite> BGImages;
    
    public int stage;

    void Start()
    {
        Init(); 
    }
    void Init()
    {
        BG.sprite = BGImages[stage];
    }
    private void Update()
    {
        UpdateProperty();
    }
    private void UpdateProperty()
    {
        GoldAmount.text = Data.gold.ToString();
        DarkMatterAmount.text = Data.darkMatter.ToString();
    }
}

