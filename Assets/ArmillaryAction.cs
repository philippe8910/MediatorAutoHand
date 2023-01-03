using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArmillaryAction : MonoBehaviour
{
    [SerializeField] private float currentAnimationTime , nextAnimationTime;
    
    [SerializeField] private bool isGrab;
    
    [SerializeField] private Animator animator;

    [SerializeField] public UnityEvent OnGrab;
    
    [SerializeField] public UnityEvent OnRelease;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out animator);
        
        OnGrab.AddListener(delegate
        {
            isGrab = true;
            currentAnimationTime = animator.GetFloat("Time");
        });
        
        OnRelease.AddListener(delegate
        {
            isGrab = false;
        });
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrab)
        {
            currentAnimationTime = Mathf.Lerp(currentAnimationTime, nextAnimationTime, 0.01f);
            
            animator.Play("Rotate");
            animator.SetFloat("Time" , currentAnimationTime);
        }
    }

    public void SetAnimationTime(float time)
    {
        nextAnimationTime = time;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            animator.CrossFade("Start" , 0.1f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            animator.CrossFade("Default" , 0.5f);
        }
    }
}
