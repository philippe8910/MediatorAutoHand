using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class RunState :  IState
{
    private float stepTime = 0;
    
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("Run" , 0.1f);
        
        if(actions.isStateLog) Debug.Log("Run Enter!!");
        
        actions.FootStepAudio().clip = actions.FootstepAudioData().GetFootstepSound(1);
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        var isJoystickInput = PlayerInputAction.JoystickActionInput() == Vector2.zero;
        var isJump = PlayerInputAction.GetJumpActionBoolean();
        var isFalling = actions.GetFallingDetected() && !actions.GetGroundDetected();

        var runVector = PlayerInputAction.JoystickActionInput() * actions.ActorData().speed * Time.deltaTime;
        
        stepTime += Time.deltaTime;

        if (stepTime > 0.4f)
        {
            actions.FootStepAudio().clip = actions.FootstepAudioData().GetFootstepSound(1);
            actions.FootStepAudio().Play();
            stepTime = 0;
        }

        

        actions.moveVector = runVector;
        
        actions.StateListener(new StopRunningState() , isJoystickInput);
        actions.StateListener(new JumpState() , isJump);
        actions.StateListener(new FallingState() , isFalling);
        
        if(actions.isStateLog) Debug.Log("Run Stay!!");
    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Run Exit!!");
    }
}
