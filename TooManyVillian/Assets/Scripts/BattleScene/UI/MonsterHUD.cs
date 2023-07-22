using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class MonsterHUD : MonoBehaviour
{
    public BaseCharacterController monster;

    public Image myImage;

    private void Awake()
    {
        monster = GetComponentInParent<BaseCharacterController>();
    }
    private void LateUpdate()
    {
       
        float maxHp = monster.maxHealth;
        float curHp = monster.health;
        myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, curHp / maxHp / 1 / 1, Time.deltaTime * 5); // 좀 천천히 줄어들도록 함
    }
}
