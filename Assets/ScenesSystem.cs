using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class ScenesSystem : MonoBehaviour
{
    private Animator animator;

    private Action endAction;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animator>(out animator);
        
        EventBus.Subscribe<ChangeScenesDetected>(OnChangeScenesDetected);
    }

    [Button]
    public void ChangeScenesTest()
    {
        EventBus.Post(new ChangeScenesDetected(delegate { Debug.Log("Change Test"); }));
    }
    
    private void OnChangeScenesDetected(ChangeScenesDetected obj)
    {
        var actions = obj.action;

        endAction = actions;
        
        animator.Play("FadeOut");
        
        StartCoroutine(StartDetected());
    }

    private IEnumerator StartDetected()
    {
        var info = animator.GetCurrentAnimatorStateInfo(0);

        if (info.normalizedTime >= 1)
        {
            endAction?.Invoke();
            yield return null;
        }
        else
        {
            yield return new WaitForFixedUpdate();
            StartCoroutine(StartDetected());
        }
    }
}
