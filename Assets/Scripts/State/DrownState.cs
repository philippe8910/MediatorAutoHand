using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrownState : IState
{
    public void OnEnterState(object action)
    {
        var actor = (AamonAction) action;
        
        actor.Animator().CrossFade("Drown" , 0.1f);
        actor.Rigidbody().useGravity = false;
    }

    public void OnStayState(object action)
    {
        var actor = (AamonAction) action;
        
        actor.Rigidbody().velocity = Vector3.down * Time.deltaTime * 10;
    }

    public void OnExitState(object action)
    {
        
    }
}
