using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimeControlSphere : MonoBehaviour
{
    [SerializeField] private UnityEvent OnPlayerTriggerOn;

    [SerializeField] private GameObject targetArmillary;
    
    // Start is called before the first frame update
    void Start()
    {
        targetArmillary.SetActive(false);
        
        OnPlayerTriggerOn.AddListener(delegate
        {
            targetArmillary.SetActive(true);
        });
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnPlayerTriggerOn?.Invoke();
        }
    }
}
