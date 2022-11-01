using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

[RequireComponent(typeof(Grabbable))]
public class GrabbableNormalCube : MonoBehaviour
{
    private Grabbable grabbable;

    private Animator animator;

    [SerializeField] private LayerMask onGrabLayerMask;
    
    [SerializeField] private LayerMask onReleaseLayerMask;
    

    private void OnEnable()
    {
        TryGetComponent<Animator>(out animator);

        onGrabLayerMask = 256;
        onReleaseLayerMask = 512;
        
        grabbable.onGrab.AddListener(delegate(Hand arg0, Grabbable grabbable1)
        {
            animator.CrossFade("OnGrab" , 0.1f);
            gameObject.layer = onGrabLayerMask;
        });
        grabbable.onRelease.AddListener(delegate(Hand arg0, Grabbable grabbable1)
        {
            animator.CrossFade("OnRelease" , 0.1f);
            gameObject.layer = onReleaseLayerMask;
        });
    }
}
