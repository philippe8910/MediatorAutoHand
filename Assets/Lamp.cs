using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.VFX;

public class Lamp : MonoBehaviour
{
    public int correctAnswerIndex;
    
    [SerializeField] private Animator hintCanvasAnimator; // 提示顯現動畫

    [SerializeField] private VisualEffect fireEffect; //火焰的VFX特效

    [SerializeField] private ParticleSystem fireLight; //火焰的光線ParticleSystem

    [SerializeField] private AudioSource fireAudioSource;

    [SerializeField] private GameObject hintText; //點火後才顯示的熄滅提示按鈕

    [SerializeField] private UnityEvent OnPlayerEnter; //當玩家進入提示區域
    
    [SerializeField] private UnityEvent OnPlayerExit; //當玩家離開提示區域

    [SerializeField] private UnityEvent OnPlayerInteractive; //當玩家對提示區域內使用互動(熄滅)
    
    [SerializeField] private UnityEvent OnPlayerLightTheTorch; //當玩家點燃提示區域

    [SerializeField] private Level_4_Task task;

    [SerializeField] private bool isEnter;
    private void Start()
    {
        task = FindObjectOfType<Level_4_Task>();
        
        fireEffect.Stop();
        fireLight.Stop();
        
        
        OnPlayerEnter.AddListener(delegate
        {
            hintCanvasAnimator.Play("FadeIn");
        });
        
        OnPlayerExit.AddListener(delegate
        {
            hintCanvasAnimator.Play("FadeOut");
        });
        
        OnPlayerLightTheTorch.AddListener(delegate
        {
            fireAudioSource.Play();
            
            fireLight.gameObject.SetActive(true);
            
            fireEffect.Play();
            fireLight.Play();
            
            hintText.gameObject.SetActive(true);

            task.OnPlayerLightTheFireDetected(true , this);
        });
        
        OnPlayerInteractive.AddListener(delegate
        {
            fireAudioSource.Stop();
            
            fireLight.gameObject.SetActive(false);
            
            fireEffect.Stop();
            fireLight.Stop();
            
            hintText.gameObject.SetActive(false);
            
            task.OnPlayerLightTheFireDetected(false , this);
        });
    }

    [Button]
    public void LightingTest()
    {
        OnPlayerLightTheTorch.Invoke();
    }

    [Button]
    public void DisLightingTest()
    {
        OnPlayerInteractive.Invoke();
    }

    private void Update()
    {
        if (isEnter)
        {
            if (PlayerInputAction.GetInteractiveActionBoolean())
            {
                OnPlayerInteractive?.Invoke();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerEnter?.Invoke();
            isEnter = true;
        }

        if (other.gameObject.CompareTag("Torch"))
        {
            OnPlayerLightTheTorch?.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            OnPlayerExit?.Invoke();
            isEnter = false;
        }
    }
}
