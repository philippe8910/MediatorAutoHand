using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEvents : MonoBehaviour
{
    public bool isEnter;

    public LayerMask enterLayer;

    // Update is called once per frame
    void Update()
    {
        if (isEnter)
        {
            OnTrigger();
        }
        else
        {
            OnRelease();
        }
    }
    
    public virtual void OnRelease()
    {
    }

    public virtual  void OnTrigger()
    {
    }

    public void OnTriggerEnter(Collider other)
    {
        isEnter = true;
    }

    public void OnTriggerExit(Collider other)
    {
        isEnter = false;
    }
}
