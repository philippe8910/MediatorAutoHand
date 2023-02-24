using UnityEngine;
using Event;
using Project;

[RequireComponent(typeof(LevelEvents))] // 要求此腳本所在的 GameObject 必須有 LevelEvents 組件
public class SteleAction : MonoBehaviour
{
    [SerializeField] private string hintText; // 用於提示的文字

    private LevelEvents levelEvents; // LevelEvents 組件的引用

    private void Start()
    {
        // 獲取並存儲 LevelEvents 組件的引用
        levelEvents = GetComponent<LevelEvents>();
        
        // 註冊 OnTieRodTrigger 事件的監聽器，當事件觸發時，會發送 OnEnableLevelHintDetected 事件，並傳遞 hintText
        levelEvents.OnTieRodTrigger.AddListener(delegate
        {
            EventBus.Post(new OnEnableLevelHintDetected(hintText));
        });
    }
}