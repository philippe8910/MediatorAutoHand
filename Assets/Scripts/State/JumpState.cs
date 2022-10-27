using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorState("IsJump" , true);
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
    }

    public void OnExitState(object action)
    {
        //action.SetAnimatorState(action.jumpUpState , false);

    }
}
