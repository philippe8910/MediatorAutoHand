using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkState : IState
{
    public void OnEnterState(object action)
    {
       /*
        *  action.SetAnimatorState(action.walkState , true);
        action.characterActor().SetSpeed(15f);
        */
    }

    public void OnStayState(object action)
    {
        /*
         * Debug.Log("walkState!!!!!");
        
        if (action.GetInputVector2() == Vector2.zero)
        {
            action.ChangeState(new IdleState());
        }

        if (action.ControllerAction().GetRunButton())
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

        action.characterActor().Movement(action.GetInputVector2());
        action.SetAnimatorState(action.landingState , true);
         */

    }

    public void OnExitState(object action)
    {
       // action.SetAnimatorState(action.walkState , false);
    }
}
