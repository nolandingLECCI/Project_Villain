using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageText : MonoBehaviour
{


    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    void Start()
    {
        float randForce = Random.Range(-1f, 1f);
        rigid.AddForce((Vector2.up * 5f) + (Vector2.right * randForce), ForceMode2D.Impulse);
    }

}
