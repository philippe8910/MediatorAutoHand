using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorState("IsRunning" , true);
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        var joystickInput = actions.PlayerInputAction().JoystickActionInput() == Vector2.zero;
        
        actions.Movement(actions.PlayerInputAction().JoystickActionInput());
        
        if (joystickInput)
        {
            actions.ChangeState(new IdleState());
        }
    }

    public void OnExitState(object action)
    {
        //action.SetAnimatorState(action.runState , false);
    }
}
