using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AamonActor
{
    private float speed = 45;
    
    private float groundTriggerRange = 0.02f;

    private float climbTirggerRange = 0.02f;

    private Rigidbody rigidbody;

    private Animator animator;

    public Vector3 groundOffset = new Vector3(0,0.01f ,0);

    public void Start(Rigidbody _rigidbody , Animator _animator)
    {
        rigidbody = _rigidbody;
        animator = _animator;
    }

    public Rigidbody Rigidbody()
    {
        return rigidbody;
    }

    public float Speed()
    {
        return speed;
    }

    public float GroundTriggerRange()
    {
        return groundTriggerRange;
    }
    
    public float ClimbTriggerRange()
    {
        return climbTirggerRange;
    }
    
    public Animator Animator()
    {
        return animator;
    }
    
    public bool GetGroundDetected(Transform player)
    {
        return Physics.CheckSphere(player.position + groundOffset, GroundTriggerRange(), 128);
    }

    public bool GetFallingDetected()
    {
        return Rigidbody().velocity.y < 0.1;
    }

}
