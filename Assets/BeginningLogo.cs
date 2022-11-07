using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BeginningLogo : MonoBehaviour
{
    public UnityEvent OnStart;
    
    PlayerInputAction playerInputAction = new PlayerInputAction();

    // Update is called once per frame
    void Update()
    {
        if (playerInputAction.GetTriggerBoolean())
        {
            
            OnStart.Invoke();
        }
    }
}
