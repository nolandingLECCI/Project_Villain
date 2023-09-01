using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // 싱글톤을 할당할 전역 변수

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
}
