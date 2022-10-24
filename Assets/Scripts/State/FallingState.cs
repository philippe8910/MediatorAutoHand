using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState :  IState
{
    public void OnEnterState(object action)
    {
        //action.SetAnimatorState(action.fallingState , true);
    }

    public void OnStayState(object action)
    {
        /*
         * if (action.GetIsClimb())
        {
            action.ChangeState(new ClimbState());
        }
        
        if (action.GetIsGround())
        {
            action.ChangeState(new JumpDownState());
        }
         */
    }

    public void OnExitState(object action)
    {
        //action.SetAnimatorState(action.fallingState , false);

    }
}
