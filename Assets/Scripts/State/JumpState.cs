using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState :  IState
{
    public void OnEnterState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.jumpUpState , true);
        action.characterActor().Jump();
    }

    public void OnStayState(CharacterStateAction action)
    {
        Debug.Log("jumpState!!!!!");

        if (action.GetIsClimb())
        {
            action.ChangeState(new ClimbState());
        }
        
        if (action.characterActor().GetFallAction())
        {
            action.ChangeState(new FallingState());
        }
    }

    public void OnExitState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.jumpUpState , false);

    }
}
