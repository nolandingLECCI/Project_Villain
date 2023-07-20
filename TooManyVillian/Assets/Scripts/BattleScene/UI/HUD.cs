using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Hp, CoolTime, Profile, Synergy1, Synergy2 };
    
    public int playerIndex; // 플레이어의 인덱스

    public InfoType type;

    public Text myText;
    public Image myImage;

    private void Awake()
    {
        //myText = GetComponentInChildren<Text>();
        //myImage = GetComponentInChildren<Image>();
    }

    private void LateUpdate()
    {

        if(BattleSceneManager.instance.playerGroup.characterGroup.Count > 0 && BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].IsAlive) // 한마리라도 생성한 경우 UI를 업데이트 해준다.
        {
            switch (type)
            {
                case InfoType.Hp:
                    {
                        float maxHp = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].maxHealth;
                        float curHp = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].health;
                        myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, curHp / maxHp / 1 / 1, Time.deltaTime * 5); // 좀 천천히 줄어들도록 함

                        myText.text = curHp + " / " + maxHp;
                    }
                    break;

                case InfoType.CoolTime:
                    {
                        if(BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].attackBehaviours.Count > 1) // 스킬이 2개 이상인 경우에만
                        {
                            float coolTime = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].attackBehaviours[1].coolTime;
                            float calcCoolTime = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].attackBehaviours[1].calcCoolTime;
                            
                            myImage.fillAmount = calcCoolTime / coolTime;

                            // 텍스트는 일단 빼두었다.
                        }
                       
                    }

                    break;

                case InfoType.Profile: // 캐릭터에게 아이콘 달기만 하면 된다.
                    {
                        //myImage =  BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].profileSprite;
                    }
                    break;

                case InfoType.Synergy1: // 시너지쪽에서 Awake 할 때 Icon을 해당하는 자식 시너지에서 로드하는 식으로 하면 된다. 
                    {
                        myImage.sprite = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].synergys[0].synergyIcon;
                    }
                    break;

                case InfoType.Synergy2:
                    {
                        if (BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].synergys.Count > 1)  // 시너지가 2개 이상인 경우에만
                        {
                            myImage.sprite = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex].synergys[1].synergyIcon;
                        }
                    }
                    break;
            }
        }
       

    }

}
