using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimatorEvents : MonoBehaviour
{
    public UnityEvent OnTrigger;

    public UnityEvent OnLaterTrigger;

    public void Invoke()
    {
        OnTrigger.Invoke();
    }

    public void LaterInvoke()
    {
        OnLaterTrigger.Invoke();
    }
}
