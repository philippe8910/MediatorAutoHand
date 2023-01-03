using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CapsuleCollider))]
public class TouchEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTouchEnter;

    [SerializeField] private CapsuleCollider collider;

    private void Start()
    {
        collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            OnTouchEnter?.Invoke();
        }
    }
}
