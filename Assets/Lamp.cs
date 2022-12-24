using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
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

    [SerializeField] private GameObject hintText; //點火後才顯示的熄滅提示按鈕

    [SerializeField] private UnityEvent OnPlayerEnter; //當玩家進入提示區域
    
    [SerializeField] private UnityEvent OnPlayerExit; //當玩家離開提示區域

    [SerializeField] private UnityEvent OnPlayerInteractive; //當玩家對提示區域內使用互動(熄滅)
    
    [SerializeField] private UnityEvent OnPlayerLightTheTorch; //當玩家點燃提示區域

    [SerializeField] private bool isEnter;
    private void Start()
    {
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
            fireEffect.Play();
            fireLight.Play();
            
            hintText.gameObject.SetActive(true);

            EventBus.Post(new PlayerLightTheFireDetected(this , true));
        });
        
        OnPlayerInteractive.AddListener(delegate
        {
            fireEffect.Stop();
            fireLight.Stop();
            
            hintText.gameObject.SetActive(false);
            
            EventBus.Post(new PlayerLightTheFireDetected(this , false));
        });
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
