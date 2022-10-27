using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AamonActor : MonoBehaviour
{
    private float speed = 40;
    
    private float groundTriggerRange = 0.03f;

    private float climbTirggerRange = 0.03f;

    private Rigidbody rigidbody;

    private Animator animator;

    [SerializeField] private Vector3 groundOffset;

    [SerializeField] private LayerMask groundLayerMask;

    void Start()
    {
        TryGetComponent<Rigidbody>(out rigidbody);
        TryGetComponent<Animator>(out animator);
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

    public Vector3 GroundOffset()
    {
        return transform.position + groundOffset;
    }

    public Animator Animator()
    {
        return animator;
    }
    
    public bool GetGroundDetected()
    {
        LayerMask ground = LayerMask.NameToLayer("Ground");
        
        return Physics.CheckSphere(GroundOffset(), GroundTriggerRange(), groundLayerMask);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(transform.position + groundOffset , groundTriggerRange);
    }
    
}
