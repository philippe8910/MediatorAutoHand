using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AamonActor : MonoBehaviour
{
    private float speed;

    private Rigidbody rigidbody;

    private float groundTriggerRange = 0.03f;

    private float climbTirggerRange;

    private Vector3 groundOffset;
    

    void Start()
    {
        TryGetComponent<Rigidbody>(out rigidbody);
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        
        Gizmos.DrawSphere(transform.position + groundOffset , groundTriggerRange);
    }
}
