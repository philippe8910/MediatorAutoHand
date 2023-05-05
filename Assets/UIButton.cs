using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autohand;
using Autohand.Demo;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using Valve.VR;

[RequireComponent(typeof(BoxCollider))]
public class UIButton : MonoBehaviour
{
    public bool isClick = false;

    public bool rightHandPose
    {
        get { return grabPose[SteamVR_Input_Sources.RightHand].stateDown; }
    }
    
    public bool leftHandPose
    {
        get { return grabPose[SteamVR_Input_Sources.LeftHand].stateDown; }
    }

    public AudioSource buttonSound;

    public SteamVR_Action_Boolean grabPose;

    public UIButton[] uiButton;
    
    public UnityEvent OnClick;

    public UnityEvent OnHandTriggerEnter;

    public UnityEvent OnHandTriggerExit;

    private void Start()
    {
        uiButton = FindObjectsOfType<UIButton>();
        buttonSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hand") && other.GetComponent<SteamVRHandControllerLink>().handType == SteamVR_Input_Sources.LeftHand && leftHandPose)
        {
            PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.LeftHand , 0.2f);
            OnClick.Invoke();
            buttonSound.Play();
        }
        
        if (other.CompareTag("Hand") && other.GetComponent<SteamVRHandControllerLink>().handType == SteamVR_Input_Sources.RightHand && rightHandPose)
        {
            PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.RightHand , 0.2f);
            OnClick.Invoke();
            buttonSound.Play();
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
