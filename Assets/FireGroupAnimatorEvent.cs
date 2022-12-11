using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FireGroupAnimatorEvent : MonoBehaviour
{
    public Animator animator;

    public UnityEvent OnFireRunEnd;
    
    private void Start()
    {
        TryGetComponent<Animator>(out animator);
    }

    public void OnFireEnd()
    {
        OnFireRunEnd.Invoke();
    }
}
