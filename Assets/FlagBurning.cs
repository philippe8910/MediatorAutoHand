using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class FlagBurning : MonoBehaviour
{
    [SerializeField] private Material currentMaterial; // 當前的材質

    [SerializeField] [Range(0.1f , 5f)]
    private float speed;

    private float currentHeight;  // 當前高度

    public UnityEvent onLevelPassEvent;  // 事件當通過一個等級時會觸發

    // Start is called before the first frame update
    void Start()
    {
        // 檢查材質是否為空
        if (currentMaterial == null)
        {
            Debug.LogError("None Material!!!");
            return;
        }

        // 將當前高度設為0
        currentMaterial.SetFloat("_CurrentHeight", 0);
        currentHeight = currentMaterial.GetFloat("_CurrentHeight");
    }

    [Button]
    public void BurnUpFlag()
    {
        currentMaterial.SetFloat("_CurrentHeight", 0);
        DOTween.To(() => currentMaterial.GetFloat("_CurrentHeight"), x => currentMaterial.SetFloat("_CurrentHeight", x),
                -5, speed)
            .SetEase(Ease.Linear)
            .OnStart(onLevelPassEvent.Invoke);
    }

}