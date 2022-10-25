using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorState("IsRunning" , false);
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        var joystickInput = actions.PlayerInputAction().JoystickActionInput() != Vector2.zero;
        
        if (joystickInput)
        {
            actions.ChangeState(new RunState());
        }
    }

    public void OnExitState(object action)
    {
        
    }
}
