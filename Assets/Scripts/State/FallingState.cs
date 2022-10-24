using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState :  IState
{
    public void OnEnterState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.fallingState , true);
    }

    public void OnStayState(CharacterStateAction action)
    {
        if (action.GetIsClimb())
        {
            action.ChangeState(new ClimbState());
        }
        
        if (action.GetIsGround())
        {
            action.ChangeState(new JumpDownState());
        }
    }

    public void OnExitState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.fallingState , false);

    }
}
