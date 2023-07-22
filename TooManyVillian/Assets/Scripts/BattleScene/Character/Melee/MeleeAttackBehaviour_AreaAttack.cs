using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttackBehaviour_AreaAttack : AttackBehavior
{
    public ManualCollision attackCollision;

    [SerializeField]
    private float MultNum = 2.5f; // 기본적으로 공격 스킬에 곱해주는 mult 수치

    protected override void Awake()
    {
        base.Awake();

        defaultMult = MultNum;
        damage = (int)(damage * defaultMult);
    }

    public override void ExecuteAttack(GameObject target = null, Transform startPoint = null, float attackMult = 1f)
    {


        Collider2D[] colliders = attackCollision?.CheckOverlapBox(targetMask);

        BaseCharacterController character = this.GetComponent<BaseCharacterController>();

        foreach (Collider2D collider in colliders)
        {
            collider.gameObject.GetComponent<IDamageable>()?.TakeDamage((int)(damage * attackMult), hitEffectPrefab);
            collider.gameObject.GetComponent<BaseCharacterController>()?.KnockBack(knockBackForce);

            if (character != null && character.isVampire) // 캐릭터가 Null이 아니며, Vampire인 경우
            {
                if (character.health + (int)(damage * attackMult * 0.2f) >= character.maxHealth)
                {
                    character.health = character.maxHealth;
                }
                else
                {
                    character.health += (int)(damage * attackMult * 0.2f); // 가한 데미지의 20퍼센트만큼씩 회복
                }
               
            }
        }

        calcCoolTime = 0.0f;
    }

    public override void ExecuteParticle(GameObject particle = null, Transform startPoint = null)
    {
        if(particle != null)
        {

        }
    }
}
