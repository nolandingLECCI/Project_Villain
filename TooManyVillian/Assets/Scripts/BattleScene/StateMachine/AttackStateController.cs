using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateController : MonoBehaviour
{
    public delegate void OnEnterAttackState();
    public delegate void OnExitAttackState();

    public OnEnterAttackState enterAttackStateHandler;
    public OnExitAttackState exitAttackStateHandler;

    public bool IsInAttackState
    {
        get;
        private set;
    }

    void Start()
    {
        enterAttackStateHandler = new OnEnterAttackState(EnterAttackState);
        exitAttackStateHandler = new OnExitAttackState(ExitAttackState);
    }
    
    #region Helper Methods

    public void OnStartOfAttackState()
    {
        IsInAttackState = true;
        enterAttackStateHandler();
    }
    
    public void OnEndOfAttackState()
    {
        IsInAttackState = false;
        exitAttackStateHandler();
    }

    private void EnterAttackState()
    {

    }

    private void ExitAttackState()
    {

    }

    public void OnCheckAttackCollider(int attackIndex)
    {
         GetComponent<IAttackable>()?.OnExecuteAttack(attackIndex);

    }


    public void SlashEffectActive(int attackIndex)
    {
        GetComponent<BaseCharacterController>()?.OnExcuteParticleSystem(attackIndex);
    }
    
    #endregion Helper Methods

   
    
}
