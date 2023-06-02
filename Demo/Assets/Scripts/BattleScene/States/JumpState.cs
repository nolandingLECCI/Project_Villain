using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class JumpState : State<BaseCharacterController>
{
    public Animator animator;

    public override void OnInitialized()
    {
        animator = context.GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        animator?.SetTrigger("Jump");
    }

    public override void Update(float deltaTime)
    {
     
        if(context.jumpTrigger == false)
        {
            stateMachine.ChangeState<NonCombatMoveState>();
        }

    }

    public override void OnExit()
    {
       
    }
}
