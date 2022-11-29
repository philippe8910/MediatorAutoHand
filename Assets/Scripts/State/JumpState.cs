using System;
using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class JumpState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        var jumpVector = actions.Rigidbody().velocity;

        jumpVector = new Vector3(jumpVector.x, 1.5f, jumpVector.z);
        
        actions.SetAnimatorCrossState("Jump" , 0.01f);
        actions.Rigidbody().AddForce(jumpVector , ForceMode.Impulse);
        
        if(actions.isStateLog) Debug.Log("Jump Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        var isLanding = actions.GetGroundDetected();
        
        var runVector = PlayerInputAction.JoystickActionInput() * actions.ActorData().speed * Time.deltaTime;
        
        actions.moveVector = runVector;
        
        actions.StateListener(new LandingState() , isLanding);

        if(actions.isStateLog) Debug.Log("Jump Stay!!");
    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Jump Exit!!");
    }
}
