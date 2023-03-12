using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConnonAction : MonoBehaviour
{
    [SerializeField] private bool isLock = true , isReload = false;

    [SerializeField] private UnityEvent OnFireTrigger;

    public void SetLock(bool _isLook)
    {
        isLock = _isLook;
    }

    public void SetReload(bool _isReload)
    {
        isReload = _isReload;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            if (!isLock)
            {
                OnFireTrigger.Invoke();
            }
        }
    }
}
