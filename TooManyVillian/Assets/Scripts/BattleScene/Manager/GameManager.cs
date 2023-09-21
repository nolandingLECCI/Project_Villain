using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수
    public GameDataManager Data;
    public List<Animator> m_animator;
    [SerializeField] private List<CharacterData> m_BattleCharaData;
    public GameObject[] playerCharacters;
    public GameObject[] enemyGroups;
    public GameObject bossCharacter;

    private void Awake()
    {
        if (null == instance)
        {
            // 씬 시작될때 인스턴스 초기화, 씬을 넘어갈때도 유지되기위한 처리
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // instance가, GameManager가 존재한다면 GameObject 제거 
            Destroy(this.gameObject);
        }
        Init();
    }

    public GameObject[] GetCharacterList() 
    {
        return playerCharacters;
    }

    public GameObject GetEnemyList(int enemyWave)
    {
        return enemyGroups[enemyWave];
    }

    public GameObject GetBoss()
    {
        return bossCharacter;
    }

    private void Init()
    {
        m_BattleCharaData = Data.GameData.BattleCharaData;
        if(m_BattleCharaData!=null)
        {
            SetupCharacters();
        }
    }
    private void SetupCharacters()
    {
        BaseCharacterController controller;
        Animator animator;
        for(int i = 0 ; i<playerCharacters.Length ; i++)
        {
            controller = playerCharacters[i].GetComponent<BaseCharacterController>();
            controller.maxHealth = (int)m_BattleCharaData[i].m_Vil_Hp;
            controller.strength = (int)m_BattleCharaData[i].m_Vil_Str;
            controller.attackRange = (int)m_BattleCharaData[i].m_Range_Normal;

            animator = playerCharacters[i].GetComponent<Animator>();
            if(m_BattleCharaData[i].m_weapon == "LongSword")
            {
                animator.runtimeAnimatorController = Resources.Load("GameData/Animator/LongKnife") as RuntimeAnimatorController;
            }
        }
        
    }

}
