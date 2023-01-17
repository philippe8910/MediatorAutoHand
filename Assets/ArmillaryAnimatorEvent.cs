using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmillaryAnimatorEvent : MonoBehaviour
{
    public GameObject armillaryGameObject;
    
    private void Start()
    {
        TryGetComponent(out Animator animator);

        StartCoroutine(StartDetected());

        IEnumerator StartDetected()
        {
            AnimatorStateInfo info = animator.GetCurrentAnimatorStateInfo(0);
            
            if (info.normalizedTime < 1)
            {
                yield return new WaitForSeconds(.02f);
                Debug.Log(info.normalizedTime);
                StartCoroutine(StartDetected());
            }
            if(info.normalizedTime >= 1)
            {
                armillaryGameObject.SetActive(true);
                gameObject.SetActive(false);
                Debug.Log("Detecting!!!");
                yield return null;
            }
        }
    }
}
