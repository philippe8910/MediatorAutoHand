using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AamonAction : MonoBehaviour
{
    [SerializeField] protected IState currentState = new IdleState();

    [SerializeField] protected AamonActor actor;

    [SerializeField] protected PlayerInputAction playerInputAction;

    public Action runAction, jumpAction, climbAction;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<AamonActor>(out actor);
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

    public bool GetGroundDetected()
    {
        var ground = LayerMask.NameToLayer("Ground");
        
        return Physics.CheckSphere(actor.GroundOffset(), actor.GroundTriggerRange(), ground);
    }

    public bool GetClimbDetected()
    {
        var climb = LayerMask.NameToLayer("Climb");
        
        return Physics.CheckSphere(actor.GroundOffset(), actor.GroundTriggerRange(), climb); 
    }
}
