using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum InfoType { Hp, CoolTime, Profile, Synergy1, Synergy2, Shield };
    public int playerIndex; // 플레이어의 인덱스
    public InfoType type;
    public Text myText;
    public Image myImage;
    private bool isCreate;
    private bool isEnd;
    private float maxHpData;
    
    private BaseCharacterController character;

    private void LateUpdate()
    {

        if(BattleSceneManager.instance.playerGroup.characterGroup.Count > 0) // 한마리라도 생성한 경우 UI를 업데이트 해준다.
        {
            if(!isCreate)
            {
                isCreate = true;
                
                character = BattleSceneManager.instance.playerGroup.characterGroup[playerIndex];
                
                maxHpData = character.maxHealth;

            }
            
            if(isEnd)
            {

                myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, 0 / maxHpData / 1 / 1, Time.deltaTime * 5); // 좀 천천히 줄어들도록 함

                myText.text = 0 + " / " + maxHpData;

                return;
            }

            switch (type)
            {
                case InfoType.Hp:
                    {
                        float maxHp = character.maxHealth;
                        float curHp = character.health;
                        myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, curHp / maxHp / 1 / 1, Time.deltaTime * 5); // 좀 천천히 줄어들도록 함

                        myText.text = curHp + " / " + maxHp;

                        if (curHp <= 0)
                        {
                            isEnd = true;   
                            
                        }
                    }
                    break;

                case InfoType.Shield:
                    {
                        float curShield = character.healthAdd;

                        if(curShield > 0)
                        {
                            myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, curShield / maxHpData / 1 / 1, Time.deltaTime * 5);
                        }

                        else
                        {
                            myImage.fillAmount = Mathf.Lerp(myImage.fillAmount, 0 / maxHpData / 1 / 1, Time.deltaTime * 5);
                        }


                        break;
                    }

                case InfoType.CoolTime:
                    {
                        if(character.attackBehaviours.Count > 1) // 스킬이 2개 이상인 경우에만
                        {
                            float coolTime = character.attackBehaviours[1].coolTime;
                            float calcCoolTime = character.attackBehaviours[1].calcCoolTime;
                            
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
                        myImage.sprite = character.synergys[0].synergyIcon;
                    }
                    break;

                case InfoType.Synergy2:
                    {
                        if (character.synergys.Count > 1)  // 시너지가 2개 이상인 경우에만
                        {
                            myImage.sprite = character.synergys[1].synergyIcon;
                        }
                    }

                    break;
            }
        }
       

    }

}
