using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTriggerEnd : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            Debug.Log("IsJumpTrigger");
            BaseCharacterController character = collision.GetComponent<BaseCharacterController>();

            character.jumpTrigger = false;

        }
    }
}
