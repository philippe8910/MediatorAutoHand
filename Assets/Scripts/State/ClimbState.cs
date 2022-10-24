using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : IState
{
    public void OnEnterState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.climbState , true);
        action.characterActor().SetGravity(false);

        var climbingObject = action.GetClimbingObject();

        action.transform.rotation = climbingObject.transform.rotation;
        action.transform.position = new Vector3(action.transform.position.x, climbingObject.transform.position.y - 0.174f,
            action.transform.position.z);

        action.characterActor().SetRigidbodyVector(Vector3.zero);
    }

    public void OnStayState(CharacterStateAction action)
    {
       // action.characterActor().SetRigidbodyVector2(new Vector3(action.transform.position.x, 0, 0) + action.transform.right);

       if (action.GetInputVector2().x > 0.2f && action.GetRightSideClimbWallCheck())
       {
           action.characterActor().SetRigidbodyVector(action.transform.right * Time.deltaTime * 7);
           action.SetAnimatorState("ClimbInputAxis" , action.GetInputVector2().x);
       }
       else if(action.GetInputVector2().x < -0.2f && action.GetLeftSideClimbWallCheck())
       {
           action.characterActor().SetRigidbodyVector(-action.transform.right * Time.deltaTime * 7);
           action.SetAnimatorState("ClimbInputAxis" , action.GetInputVector2().x);
       }
       else
       {
           action.characterActor().SetRigidbodyVector(Vector2.zero);
           action.SetAnimatorState("ClimbInputAxis" , action.GetInputVector2().x);
       }

       if (action.ControllerAction().GetJumpButton())
       {
           action.ChangeState(new JumpState());
       }
       
       
    }

    public void OnExitState(CharacterStateAction action)
    {
        action.SetAnimatorState(action.climbState , false);
        action.characterActor().SetGravity(true);
        action.DelayClimb();
    }
}
