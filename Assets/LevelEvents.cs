using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using Valve.VR;

public class LevelEvents : MonoBehaviour
{
    public LayerMask enterLayer;
    
    public List<GameObject> enterObject = new List<GameObject>();

    [AutoToggleHeader("TriggerArea")]
    public bool useTriggerArea = true;
    
    [EnableIf("useTriggerArea")]
    public bool isEnter;
    
    [EnableIf("useTriggerArea")]
    public bool isOnlyPlayer;

    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerEnterEvent;
    
    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerStayEvent;
    
    [EnableIf("useTriggerArea")]
    [SerializeField] public UnityEvent OnTriggerExitEvent;

    [AutoToggleHeader("TieRod")]
    public bool useTieRod = true;

    [EnableIf("useTieRod")]
    public UnityEvent OnTieRodTrigger;

    [EnableIf("useTieRod")]
    public UnityEvent OnTieRodRelease;

    [EnableIf("useTieRod")]
    public bool isTrigger;

    private void Update()
    {
        OnTick();
    }

    private void OnTick()
    {
        if (isEnter && PlayerInputAction.GetInteractiveActionBoolean())
        {
            isTrigger = !isTrigger;

            if (isTrigger)
            {
                OnTieRodTrigger?.Invoke();
            }
            else
            {
                OnTieRodRelease?.Invoke();
            }
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isOnlyPlayer)
        {
            if (other.CompareTag("Player"))
            {
                OnTriggerEnterEvent?.Invoke();
            }
        }
        else
        {
            if (other.GetComponent<Rigidbody>())
            {
                OnTriggerEnterEvent?.Invoke();
                
                enterObject.Add(other.gameObject);
            }
        }

        if (useTieRod && other.CompareTag("Player"))
        {
            isEnter = true;
        }
        
    }

    public void OnTriggerStay(Collider other)
    {
        if (useTriggerArea)
        {
            if (isOnlyPlayer)
            {
                if (other.CompareTag("Player"))
                {
                    OnTriggerStayEvent?.Invoke();
                }
            }
            else
            {
                if (other.GetComponent<Rigidbody>())
                {
                    OnTriggerStayEvent?.Invoke();
                }
            }

            if (useTieRod && other.CompareTag("Player"))
            {
                isEnter = true;
            }
        }
        
        
    }

    public void OnTriggerExit(Collider other)
    {
        if (useTriggerArea)
        {
            if (isOnlyPlayer)
            {
                if (other.CompareTag("Player"))
                {
                    OnTriggerExitEvent?.Invoke();
                }
            }
            else
            {
                if (other.GetComponent<Rigidbody>())
                {

                    enterObject.Remove(other.gameObject);

                    if (enterObject.Count == 0)
                    {
                        OnTriggerExitEvent?.Invoke();
                    }
                }
            }
            
            
        }
        
        if (useTieRod && other.CompareTag("Player"))
        {
            isEnter = false;
        }
    }

    public void PlayerControllerVibration()
    {
        PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.RightHand , 5);
        PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.LeftHand , 5);
    }

    public void NextLevel()
    {
        EventBus.Post(new ChangeScenesDetected(delegate
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }));
    }
    
}
