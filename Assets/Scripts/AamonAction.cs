using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class AamonAction : MonoBehaviour
{
    [SerializeField] protected IState currentState = new IdleState();

    [SerializeField] protected PlayerInputAction playerInputAction = new PlayerInputAction();
    
    [InlineEditor] [SerializeField] private ActorData actorData;

    private Rigidbody rigidbody;

    private Animator animator;

    private Transform mainCamera;

    public bool isStateLog;

    public Vector3 moveVector;
    
    //public Action runAction, jumpAction, climbAction;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody>(out rigidbody);
        TryGetComponent<Animator>(out animator);

        mainCamera = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStayState(this);
    }

    private void FixedUpdate()
    {
        Movement(moveVector);
    }

    public Rigidbody Rigidbody()
    {
        return rigidbody;
    }

    public Animator Animator()
    {
        return animator;
    }

    public ActorData ActorData()
    {
        return actorData;
    }
    
    public PlayerInputAction PlayerInputAction()
    {
        return playerInputAction;
    }

    public bool GetGroundDetected()
    {
        return Physics.CheckSphere(transform.position + actorData.groundOffset, actorData.groundTriggerRange, actorData.groundLayerMask);
    }

    public bool GetOverHeadDetected()
    {
        return Physics.CheckSphere(transform.position + actorData.overHeadOffset, actorData.overHeadTriggerRange);
    }
    
    public bool GetFallingDetected()
    {
        return rigidbody.velocity.y < 0.1;
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExitState(this);
        newState.OnEnterState(this);
        currentState = newState;
    }
    
    public void Movement(Vector2 input)
    {
        Vector3 move = new Vector3(input.x, 0, input.y);
        
        move = Quaternion.AngleAxis(mainCamera.transform.rotation.eulerAngles.y, Vector3.up) * move;
        move.Normalize();

        rigidbody.velocity = new Vector3(input.x * actorData.speed * Time.deltaTime, rigidbody.velocity.y,
            input.y * actorData.speed * Time.deltaTime);

        if (input != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(input.x , input.y) * Mathf.Rad2Deg, 0));
        }
    }

    public void SetAnimatorCrossState(string stateName , float setFixedTime)
    {
        animator.CrossFade(stateName , setFixedTime);
    }
    
    public void StateListener(IState state , bool value)
    {
        if(value)
        {
            ChangeState(state);
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(transform.position + actorData.groundOffset , actorData.groundTriggerRange);
        Gizmos.DrawSphere(transform.position + actorData.overHeadOffset , actorData.overHeadTriggerRange);
    }
}
