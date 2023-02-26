using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class GroundEmissionAction : MonoBehaviour
{
    [SerializeField] private Animator doorAnimation;
    
    private Material material;
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    [Button]
    public void FadeIn()
    {
        DOTween.KillAll();
        DOTween.To(() => material.GetFloat("_Edge_Width"), x => material.SetFloat("_Edge_Width", x), 270, 1f)
            .SetEase(Ease.Linear)
            .OnComplete(
                delegate
                {
                    doorAnimation.CrossFade("Open" , 0.1f);
                });
    }

    [Button]
    public void FadeOut()
    {
        DOTween.KillAll();
        DOTween.To(() => material.GetFloat("_Edge_Width"), x => material.SetFloat("_Edge_Width", x), 0, 1f)
            .SetEase(Ease.Linear)
            .OnStart(
                delegate
                {
                    doorAnimation.CrossFade("Close" , 0.1f);
                });
    }
}
