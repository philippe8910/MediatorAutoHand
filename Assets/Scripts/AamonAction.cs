using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class AamonAction : MonoBehaviour
{
    [SerializeField] protected IState currentState = new IdleState();

    [SerializeField] protected AamonActor actor = new AamonActor();

    [SerializeField] protected PlayerInputAction playerInputAction = new PlayerInputAction();

    public bool isStateLog;
    
    //public Action runAction, jumpAction, climbAction;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Rigidbody>(out var rigidbody);
        TryGetComponent<Animator>(out var animator);
        
        actor.Start(rigidbody , animator);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.OnStayState(this);
    }

    public AamonActor Actor()
    {
        return actor;
    }

    public PlayerInputAction PlayerInputAction()
    {
        return playerInputAction;
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

        actor.Rigidbody().velocity = new Vector3(input.x * actor.Speed() * Time.deltaTime, actor.Rigidbody().velocity.y,
            input.y * actor.Speed() * Time.deltaTime);

        if (input != Vector2.zero)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, Mathf.Atan2(input.x , input.y) * Mathf.Rad2Deg, 0));
        }
    }
    

    public void SetAnimatorCrossState(string stateName , float setFixedTime)
    {
        actor.Animator().CrossFade(stateName , setFixedTime);
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
        
        Gizmos.DrawSphere(transform.position + actor.groundOffset , actor.GroundTriggerRange());
    }
}
