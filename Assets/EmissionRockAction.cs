using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class EmissionRockAction : MonoBehaviour
{
    [SerializeField] public Material material;

    [SerializeField] public string targetValueName;

    [SerializeField] public float maxValue, minValue;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
    }

    [Button]
    public void FadeIn()
    {
        DOTween.To(() => material.GetFloat(targetValueName), x => material.SetFloat(targetValueName, x), maxValue, 1)
            .SetEase(Ease.Linear);
    }

    [Button]
    public void FadeOut()
    {
        DOTween.To(() => material.GetFloat(targetValueName), x => material.SetFloat(targetValueName, x), minValue, 1)
            .SetEase(Ease.Linear);
    }
    
}

