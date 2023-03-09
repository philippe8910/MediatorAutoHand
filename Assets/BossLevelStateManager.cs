using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using State.BossState;
using UnityEngine;

public class BossLevelStateManager : MonoBehaviour
{
    [SerializeField] private bool isHurt;
    
    [SerializeField] private float hurtRange;

    [SerializeField] private LayerMask layerMask;

    private IState currentState = new BossIdleState();

    [SerializeField] private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

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
    public bool GetHurt() => Physics.CheckSphere(transform.position, hurtRange , layerMask);
}
