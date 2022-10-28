using System.Collections;
using System.Collections.Generic;
using State;
using UnityEngine;

public class FallingState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("OnAir" , 0.01f);
        
        if(actions.isStateLog) Debug.Log("Falling Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        var isGround = actions.Actor().GetGroundDetected();
        
        actions.StateListener(new LandingState() , isGround);
        
        if(actions.isStateLog) Debug.Log("Falling Stay!!");
    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Falling Exit!!");
    }
}
