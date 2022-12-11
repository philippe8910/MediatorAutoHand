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

    [EnableIf("useTieRod")]
    public UnityEvent OnTieRodTrigger;

    [EnableIf("useTieRod")]
    public UnityEvent OnTieRodRelease;

    [EnableIf("useTieRod")]
    public bool isTrigger;

    private void Update()
    {
        OnTick();
    }

    private void OnTick()
    {
        if (isEnter && PlayerInputAction.GetInteractiveActionBoolean())
        {
            isTrigger = !isTrigger;

            if (isTrigger)
            {
                OnTieRodTrigger?.Invoke();
            }
            else
            {
                OnTieRodRelease?.Invoke();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggerEnterEvent?.Invoke();
            }
        }

        if (useTieRod && other.CompareTag("Player"))
        {
            isEnter = true;
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggerStayEvent?.Invoke();
            }
        }
        
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (useTriggerArea)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggerExitEvent?.Invoke();
            }
        }
        
        if (useTieRod && other.CompareTag("Player"))
        {
            isEnter = false;
        }
    }
}
