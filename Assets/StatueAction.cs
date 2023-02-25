using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class StatueAction : MonoBehaviour
{
    public LevelEvents levelEvents;

    public Material targetMaterial;
    
    // Start is called before the first frame update
    void Start()
    {
        levelEvents = GetComponent<LevelEvents>();
        
        //targetMaterial = GetComponent<MeshRenderer>().materials[1];

        levelEvents.OnTriggerEnterEvent.AddListener(FadeIn);
        levelEvents.OnTriggerExitEvent.AddListener(FadeOut);
    }

    [Button]
    public void FadeIn()
    {
        DOTween.KillAll();
        DOTween.To(() => targetMaterial.GetFloat("emssion_intensity"), x => targetMaterial.SetFloat("emssion_intensity" , x), 1, 1)
            .SetEase(Ease.Linear);
    }
    
    [Button]
    public void FadeOut()
    {
        DOTween.KillAll();
        DOTween.To(() => targetMaterial.GetFloat("emssion_intensity"), x => targetMaterial.SetFloat("emssion_intensity" , x), 0, 1)
            .SetEase(Ease.Linear);
        
    }
}
