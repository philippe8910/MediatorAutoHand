using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState :  IState
{
    public void OnEnterState(object action)
    {
       // action.SetAnimatorState(action.walkState , false);
       // action.SetAnimatorState(action.runState , false);
       // action.SetAnimatorState(action.jumpUpState , false);
    }

    public void OnStayState(object action)
    {
        /*
         Debug.Log("idleState!!!!!");

        if (action.GetInputVector2() != Vector2.zero)
        {
            action.ChangeState(new RunState());
        }
        
        if (action.ControllerAction().GetJumpButton())
        {
            action.ChangeState(new JumpState());
        }

        if (action.characterActor().GetFallAction())
        {
            action.ChangeState(new FallingState());
        }
        
        action.SetAnimatorState(action.landingState , true);
         */
    }

    public void OnExitState(object action)
    {
        
    }
}
