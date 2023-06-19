using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{
    public int dir; // 1이면 오른쪽, -1이면 왼쪽
    public float height; // 높이, 현재 50면 적당하게 올라감
    public float width; // 너비, 현재 12면 적당하게 올라감
    public bool doFlip; // Flip해줘야하는지 체크

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            Debug.Log("IsJumpTrigger");
            BaseCharacterController character = collision.GetComponent<BaseCharacterController>();

            character.jumpTrigger = true;

            Rigidbody2D rigid = character.GetComponent<Rigidbody2D>();

            //Vector2 jumpVelocity = Vector2.up * Mathf.Sqrt(height *  -Physics.gravity.y);

            character.GetComponent<Rigidbody2D>().AddForce((Vector2.up * height * 5.2f) + (Vector2.right * dir * width * 2.2f), ForceMode2D.Impulse);

            if(doFlip)
            {
                character.Flip();
                character.dir *= -1;
            }
        }
    }
}
