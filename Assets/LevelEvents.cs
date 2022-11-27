using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class LevelEvents : MonoBehaviour
{
    public LayerMask enterLayer;
    
    [AutoToggleHeader("TriggerArea")]
    public bool useTriggerArea = true;
    
    [EnableIf("useTriggerArea")]
    public bool isEnter;

    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerEnterEvent;
    
    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerStayEvent;
    
    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerExitEvent;

    [AutoToggleHeader("TieRod")]
    public bool useTieRod = true;

    public UnityEvent OnTieRodTrigger;

    
    

    public void OnTriggerEnter(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.transform.GetComponent<Rigidbody>())
            {
                isEnter = true;
                OnTriggerEnterEvent?.Invoke();
            }
        }
        
        
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.transform.GetComponent<Rigidbody>())
            {
                isEnter = true;
                OnTriggerStayEvent?.Invoke();
            }
        }
        
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.transform.GetComponent<Rigidbody>())
            {
                isEnter = true;
                OnTriggerExitEvent?.Invoke();
            }
        }
        
        
    }
}
