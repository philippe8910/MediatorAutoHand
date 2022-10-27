using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Idle" , 0.1f);
        
        if(actions.isStateLog) Debug.Log("Idle Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        var joystickInput = actions.PlayerInputAction().JoystickActionInput() != Vector2.zero;
        var jumpActionBoolean = actions.PlayerInputAction().GetJumpActionBoolean();

        actions.StateListener(new JumpState(), jumpActionBoolean);
        actions.StateListener(new RunState() , joystickInput);
        
        if(actions.isStateLog) Debug.Log("Idle Stay!!");

    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Idle Exit!!");
    }
}
