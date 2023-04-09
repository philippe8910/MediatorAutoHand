using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SphereCollider))]
public class UIButton : MonoBehaviour
{
    public UnityEvent OnClick;

    public UnityEvent OnHandTriggerEnter;

    public UnityEvent OnHandTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnClick.Invoke();
        }
    }

    [Button]
    public void ResetLevel()
    {
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }));
    }

    [Button]
    public void NextLeve()
    {
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1); }));
    }

    public void QuitGame()
    {
        
    }
}
