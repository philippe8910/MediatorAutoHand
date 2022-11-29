using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IState
{
    public virtual void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Idle" , 0.5f);

        if(actions.isStateLog) Debug.Log("Idle Enter!!");
    }

    public virtual void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        var isJump = PlayerInputAction.GetJumpActionBoolean() && !actions.GetOverHeadDetected();
        var isJoystickInput = PlayerInputAction.JoystickActionInput() != Vector2.zero;
        var isFalling = actions.GetFallingDetected() && !actions.GetGroundDetected();

        actions.StateListener(new JumpState(), isJump);
        actions.StateListener(new RunState() , isJoystickInput);
        actions.StateListener(new FallingState() , isFalling);

        if(actions.isStateLog) Debug.Log("Idle Stay!!");

    }

    public virtual void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Idle Exit!!");
    }
}
