using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FadeEffectCanvas : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    
    // Start is called before the first frame update
    void Start()
    {
        if (!GetComponent<Canvas>())
        {
            Debug.LogError("No Detection Canvas Component");
            Destroy(GetComponent<CanvasGroup>());
            Destroy(this);
        }
        else
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }
    }

    [Button]
    public void EnableCanvas()
    {
        canvasGroup.DOKill();
        canvasGroup.DOFade(1, 0.01f);
    }
    
    [Button]
    public void DisableCanvas()
    {
        canvasGroup.DOKill();
        canvasGroup.DOFade(0, 0.01f);
    }

    [Button]
    public void FadeInFadeOut()
    {
        canvasGroup.DOKill();
        canvasGroup.DOFade(1, 0.1f).onComplete += delegate
        {
            canvasGroup.DOFade(0, 0.1f);
        };
    }
}
