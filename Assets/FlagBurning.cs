using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;

public class FlagBurning : MonoBehaviour
{
    [SerializeField] private Material currentMaterial;  // 當前的材質

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

        // 註冊事件，並添加對應的委託方法
        onLevelPassEvent.AddListener(() =>
        {
            // 開始燃燒旗幟
            StartCoroutine(BurnFlag());
        });
    }

    [Button]
    public void Test()
    {
        onLevelPassEvent.Invoke();
    }

    // 燃燒旗幟的協程
    IEnumerator BurnFlag()
    {
        // 不斷地降低當前高度，直到旗幟全部燃燒完畢
        while (currentHeight >= -4)
        {
            // 降低當前高度
            currentHeight -= 0.025f;
            currentMaterial.SetFloat("_CurrentHeight", currentHeight);

            // 等待一段時間再繼續執行
            yield return new WaitForSeconds(0.01f);
        }
    }
}