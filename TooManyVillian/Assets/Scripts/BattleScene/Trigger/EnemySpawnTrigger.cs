using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public int waveNum;

    private void Awake()
    {
        waveNum = 0;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("적 생성");
            BattleSceneManager.instance.CreateEnemy();
            this.gameObject.SetActive(false);

            waveNum++;
        }
    }
}
