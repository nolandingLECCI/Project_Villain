// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using System;
// using Random = UnityEngine.Random;

// public class GatchaManager : MonoBehaviour
// {
//     [SerializeField] private GatchaRate[] gatcha;
//     [SerializeField] private Transform parent, pos;
//     [SerializeField] private GameObject characterCardGO;
//     [SerializeField] private int time;

//     GameObject characterCard;
//     Cards card;
//     public GameDataManager Data;

    
//     public int cost_gatcha;
//     public int cost_scout;

//     private int cost;
//     private bool reroll=true;
//     private bool paid = false;

//     private int Num = 0;

//     public List<Characters> SelectedCharacters = new List<Characters>();

//     public void Gatcha()
//     {
//         cost = cost_gatcha;
//         if(Data.gold < cost || Data.CharacterPool.Count + time > Data.poolSize)
//         {
//             Debug.Log("돈부족 또는 캐릭터 보유 최대치 초과");
//         }
//         else
//         {
//             paid = true;
//             Data.gold -= cost;
//             reroll = true;
//             Select();
//         }
//        return;
//     }

//     CardInfo Reward(string rarity)
//     {
//         GatchaRate gr = Array.Find(gatcha , rt => rt.rarity == rarity);
//         List<CardInfo> reward = gr.reward;
//         int rnd = UnityEngine.Random.Range(0,reward.Count);
//         return reward[rnd];
//     }

//     public void GetCard()
//     {
//         if(Data.CharacterPool.Count + time < Data.poolSize)
//         {
//             for(int i = 0 ; i < time ; i++)
//             {
//                 SelectedCharacters[0].getNum = ++Num;
//                 Data.CharacterPool.Add(SelectedCharacters[0]);
//                 SelectedCharacters.RemoveAt(0);
//             }
//             paid = false;
//         }
//         else // 캐릭터 풀이 가득 찼을때
//         {
            
//         }
//         return;
//     }
//     public void Reroll()
//     {
//         if(reroll&&paid)
//         {
//             reroll = false;
//             Select();
//         }
//         else
//         {
//             Debug.Log("이미 리롤함");
//             return;
//         }
//     }
//     private void Select()
//     {
//         SelectedCharacters = new List<Characters>();
//         for(int idx = 0 ; idx < time ; idx++)
//             {
//                 characterCard = Instantiate(characterCardGO, pos.position + new Vector3(200*idx , 0 , 0), Quaternion.identity) as GameObject;
//                 characterCard.transform.SetParent(parent);
//                 characterCard.transform.localScale = new Vector3(1,1,1);
//                 card = characterCard.GetComponent<Cards>();
//                 int rnd = Random.Range(1,100);
//                 int adj = 0;
//                 for(int i = 0 ; i < gatcha.Length ; i++)
//                 {
//                     if(idx == time -1 && i == 1)    adj = 89;
//                     if(rnd <= gatcha[i].rate+adj)
//                     {
//                         card.card = Reward(gatcha[i].rarity);
//                         card.UpdateUniqueData();
//                         card.frame.sprite = gatcha[i].frame;
//                         SelectedCharacters.Add(card.card.characters);
//                         break;
//                     }
//                 }       
//             }
//     }
// }
