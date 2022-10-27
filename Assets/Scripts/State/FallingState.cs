using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState :  IState
{
    public void OnEnterState(object action)
    {
        var actions = (AamonAction) action;
        
        actions.SetAnimatorCrossState("OnAir" , 0.1f);
        
        if(actions.isStateLog) Debug.Log("Falling Enter!!");
    }

    public void OnStayState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Falling Stay!!");
    }

    public void OnExitState(object action)
    {
        var actions = (AamonAction) action;
        
        if(actions.isStateLog) Debug.Log("Falling Exit!!");
    }
}
