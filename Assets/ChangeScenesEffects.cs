using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class ChangeScenesEffects : MonoBehaviour
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

        IEnumerator StartDetected()
        {
            var info = animator.GetCurrentAnimatorStateInfo(0);

            if (info.normalizedTime >= 1 && info.IsName("FadeOut"))
            {
                endAction?.Invoke();
                //UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
                animator.Play("FadeIn");
                yield return null;
            }
            else
            {
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(StartDetected());
            }
        }

    }
}
