// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using UnityEngine.SceneManagement;

// public class MainUI : MonoBehaviour
// {
//     [SerializeField] private Image BG;
//     [SerializeField] private TextMeshProUGUI GoldAmount;
//     [SerializeField] private TextMeshProUGUI DarkMatterAmount;
//     [SerializeField] public GameDataManager Data;
//     [SerializeField] private FadeScript fade;
//     public List<Sprite> BGImages;
    
    
//     public int stage;

//     void Start()
//     {
//         Init();
//         FadeIn(); 
//     }
//     private void Update()
//     {
//         //UpdateProperty();
//     }

//     void Init()
//     {
//         BG.sprite = BGImages[stage];
//     }
//     private void UpdateProperty()
//     {
//         GoldAmount.text = Data.gold.ToString();
//         DarkMatterAmount.text = Data.darkMatter.ToString();
//     }

//     public void OnStoreClicked()
//     {
        
//     }
//     public void OnVillianClicked()
//     {

//     }
//     public void OnPromotionClicked()
//     {
//         Debug.Log("육성 화면 전환");
//         StartCoroutine(changeScene("Promotion"));
//     }
//     public void OnEmploymentClicked()
//     {
        
//     }
//     public void OnMissionSelectClicked()
//     {
        
//     }
//     public void OnSettingClicked()
//     {
        
//     }

//     public IEnumerator changeScene(string name)
//     {
//         FadeOut();
//         yield return new WaitForSeconds(1f);

//         FadeIn();
//     }

//     private void FadeIn()
//     {
//         fade.fadingIn = true;
//     }
//     private void FadeOut()
//     {
//         fade.fadingOut = true;
//     }
// }

