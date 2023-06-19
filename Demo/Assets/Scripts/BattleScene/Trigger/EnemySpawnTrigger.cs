using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnTrigger : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            Debug.Log("적 생성");
            BattleSceneManager.instance.CreateEnemy();
            this.gameObject.SetActive(false);
           
        }
    }
}
