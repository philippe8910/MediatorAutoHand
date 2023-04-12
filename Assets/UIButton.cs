using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class UIButton : MonoBehaviour
{
    public bool isClick = false;

    public UIButton[] uiButton;
    
    public UnityEvent OnClick;

    public UnityEvent OnHandTriggerEnter;

    public UnityEvent OnHandTriggerExit;

    private void Start()
    {
        uiButton = FindObjectsOfType<UIButton>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand"))
        {
            OnClick.Invoke();
        }
    }

    [Button]
    public async void ResetLevel()
    {
        if(isClick)
            return;

        isClick = true;
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = true;
        });
        
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }));
        
        await Task.Delay(3000);
        isClick = false;
        
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = false;
        });
    }

    [Button]
    public async void NextLeve()
    {
        if(isClick)
            return;

        isClick = true;
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = true;
        });
        
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1); }));

        await Task.Delay(3000);
        isClick = false;
        
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = false;
        });
    }

    public void QuitGame()
    {
        
    }

    public async void SkipTutorial()
    {
        if(isClick)
            return;

        isClick = true;
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = true;
        });
        
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(10); }));
        
        await Task.Delay(3000);
        isClick = false;
        
        uiButton.ToList().ForEach(delegate(UIButton button)
        {
            button.isClick = false;
        });
    }
}
