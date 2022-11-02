using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Run" , 0.2f);
        
        if(actions.isStateLog) Debug.Log("Run Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        var isJoystickInput = actions.PlayerInputAction().JoystickActionInput() == Vector2.zero;
        var isJump = actions.PlayerInputAction().GetJumpActionBoolean() && !actions.GetOverHeadDetected();
        var isFalling = actions.GetFallingDetected() && !actions.GetGroundDetected();

        var runVector = actions.PlayerInputAction().JoystickActionInput() * actions.ActorData().speed * Time.deltaTime;


        actions.Movement(runVector);
        
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

    public Rigidbody rigidbody { get; set; }
}
