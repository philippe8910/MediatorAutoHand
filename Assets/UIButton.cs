using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class UIButton : MonoBehaviour
{
    public UnityEvent OnClick;

    public UnityEvent OnHandTriggerEnter;

    public UnityEvent OnHandTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnClick.Invoke();
        }
    }
}
