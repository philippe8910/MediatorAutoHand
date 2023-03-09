using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class BossLevelStateManager : MonoBehaviour
{
    public BossStateEnum stateEnum;

    public string currentStateTag;

    public float hurtRange;

    private IState currentState;

    private Animator animator;

    private bool isHurt;



    public void ChangeState(IState newState)
    {
        currentState.OnExitState(this);
        newState.OnEnterState(this);

        currentState = newState;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        
        Gizmos.DrawWireSphere(transform.position , hurtRange);
    }

    public Animator GetAnimator() => animator;
    public bool GetHurt() => Physics.CheckSphere(transform.position, hurtRange);
}
