using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeAttackBehaviour_Hitscan : AttackBehavior // 원거리 캐릭터 히트 스캔 공격
{

    [SerializeField]
    private float MultNum = 1f; // 기본적으로 공격 스킬에 곱해주는 mult 수치


    protected override void Awake()
    {
        base.Awake();

        defaultMult = MultNum;
        damage = (int)(damage * defaultMult);
    }

    public override void ExecuteAttack(GameObject target = null, Transform startPoint = null, float attackMult = 1f)
    {
        target.GetComponent<IDamageable>()?.TakeDamage((int)(damage * attackMult), effectPrefab); // target은 attackTarget으로 받아온다.

        BaseCharacterController character = this.GetComponent<BaseCharacterController>();

        if (character != null && character.isVampire) // 캐릭터가 Null이 아니며, Vampire인 경우
        {
            character.health += (int)(damage * attackMult * 0.2f); // 가한 데미지의 20퍼센트만큼씩 회복
        }

        calcCoolTime = 0.0f;
    }
}
