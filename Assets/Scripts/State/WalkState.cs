using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Walk" , 0.15f);
        
        if(actions.isStateLog) Debug.Log("Walk Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        var isJoystickInput = actions.PlayerInputAction().JoystickActionInput() != Vector2.zero;
        var isJump = actions.PlayerInputAction().GetJumpActionBoolean() && !actions.GetOverHeadDetected();
        var isFalling = actions.GetFallingDetected() && !actions.GetGroundDetected();
        var isRun = actions.PlayerInputAction().JoystickActionInput().magnitude > 0.3f;

        var runVector = actions.PlayerInputAction().JoystickActionInput() * actions.ActorData().speed * Time.deltaTime;


        actions.Movement(runVector);
        
        actions.StateListener(new IdleState() , isJoystickInput);
        actions.StateListener(new RunState() , isRun && isJoystickInput);
        actions.StateListener(new JumpState() , isJump);
        actions.StateListener(new FallingState() , isFalling);
        
        if(actions.isStateLog) Debug.Log("Walk Stay!!");

    }

    public void OnExitState(object action)
    {
       // action.SetAnimatorState(action.walkState , false);
    }
}
