using DG.Tweening; // 使用 DOTween 庫來執行動畫
using Event;
using Project;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class SubtitleAction : MonoBehaviour
{
    [SerializeField] private Text subtitleText; // 文字物件的引用
    private CanvasGroup canvasGroup; // CanvasGroup 組件的引用
    
    // Start is called before the first frame update
    void Start()
    {
        // 獲取並存儲 Text 和 CanvasGroup 組件的引用
        canvasGroup = GetComponent<CanvasGroup>();
        
        // 註冊 OnEnableLevelHintDetected 事件的監聽器
        EventBus.Subscribe<OnEnableLevelHintDetected>(OnHintDetected);
    }

    // 當 OnEnableLevelHintDetected 事件觸發時，會執行此方法
    private async void OnHintDetected(OnEnableLevelHintDetected obj)
    {
        // 更新文字內容
        subtitleText.text = obj.hintSubtitleText;
        
        // 停止所有 Tween 動畫
        canvasGroup.DOKill();
        
        // 顯示文字物件，使用 DOTween 庫執行淡入動畫
        canvasGroup.DOFade(1, 0.5f);
        
        // 使用 Task.Delay 來實現延遲
        await Task.Delay(3000);

        // 隱藏文字物件，使用 DOTween 庫執行淡出動畫
        canvasGroup.DOFade(0, 0.5f);
    }

    [Button]
    public void Test()
    {
        EventBus.Post(new OnEnableLevelHintDetected("Test Test Test Test"));
    }
}