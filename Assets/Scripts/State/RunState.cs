using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Run" , 0.1f);
        
        if(actions.isStateLog) Debug.Log("Run Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        var isJoystickInput = actions.PlayerInputAction().JoystickActionInput() == Vector2.zero;
        var isJump = actions.PlayerInputAction().GetJumpActionBoolean();
        var isFalling = actions.Actor().GetFallingDetected() && !actions.Actor().GetGroundDetected();


        actions.Movement(actions.PlayerInputAction().JoystickActionInput());
        
        actions.StateListener(new IdleState() , isJoystickInput);
        actions.StateListener(new JumpState() , isJump);
        actions.StateListener(new FallingState() , isFalling);
        
        if(actions.isStateLog) Debug.Log("Run Stay!!");
    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Run Exit!!");
    }
}
