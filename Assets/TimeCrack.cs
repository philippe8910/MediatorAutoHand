using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class TimeCrack : MonoBehaviour
{
    public Animator turnTableAnimator;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            turnTableAnimator.CrossFade("Open" , 0.5f);
            turnTableAnimator.GetComponent<TrunTableAnimatorController>().isEnterArea = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            turnTableAnimator.CrossFade("Close" , 0.5f);
            turnTableAnimator.GetComponent<TrunTableAnimatorController>().isEnterArea = false;
        }
    }
}
