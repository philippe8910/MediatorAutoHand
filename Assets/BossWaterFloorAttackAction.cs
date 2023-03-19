using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

public class BossWaterFloorAttackAction : MonoBehaviour
{
    [SerializeField] private AudioSource startAttackSoundEffect;
    
    // Start is called before the first frame update
    private async void Start()
    {
        var targetPosition = GameObject.FindObjectOfType<AamonAction>().transform.position;
        
        transform.position = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);

        await Task.Delay(1500);
        
        transform.DOScale(new Vector3(transform.localScale.x, 3, transform.localScale.z), 2f).SetEase(Ease.Linear).OnStart(
                delegate
                {
                    startAttackSoundEffect.Play();
                })
            .OnComplete(delegate
            {
                Destroy(gameObject);
            });
    }
}
