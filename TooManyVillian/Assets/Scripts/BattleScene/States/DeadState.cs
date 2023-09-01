using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadState : State<BaseCharacterController>
{
    private Animator animator;

    public override void OnInitialized()
    {
        animator = context.GetComponent<Animator>();
    }

    public override void OnEnter()
    {
        animator?.SetTrigger("DoDeath");
        context.gameObject.layer = 16;
        
    }

    public override void Update(float deltaTime)
    {
        if (stateMachine.ElapsedTimeInState > 1.0f)
        {
            context.MyGroup.RemoveCharacterInGroup(context);
            GameObject.Destroy(context.gameObject);
        }
    }

    public override void OnExit()
    {
    }
}
