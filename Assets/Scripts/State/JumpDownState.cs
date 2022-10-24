using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpDownState :  IState
{
    public void OnEnterState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.landingState , true);
    }

    public void OnStayState(CharacterStateAction action)
    {
        if (action.GetIsClimb())
        {
            action.ChangeState(new ClimbState());
        }
        
        if (action.GetInputVector2() == Vector2.zero)
        {
            action.ChangeState(new IdleState());
        }
        
        if(action.GetInputVector2() != Vector2.zero)
        {
            action.ChangeState(new RunState());
        }
    }

    public void OnExitState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.landingState , false);
    }
}
