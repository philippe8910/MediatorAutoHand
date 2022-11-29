using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeginningLogo : MonoBehaviour
{
    public UnityEvent OnStart;

    // Update is called once per frame
    void Update()
    {
        if (PlayerInputAction.GetTriggerBoolean())
        {
            
            OnStart.Invoke();
        }
    }
}
