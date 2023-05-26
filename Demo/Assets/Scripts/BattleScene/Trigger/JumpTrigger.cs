using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public Transform jumpEnd; // 점프의 끝 부분
    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "Player")
        {
            Debug.Log("IsJumpTrigger");
            BaseCharacterController character = collision.GetComponent<BaseCharacterController>();

            character.jumpEnd = jumpEnd;

            character.jumpTrigger = true;
            
        }
    }
}
