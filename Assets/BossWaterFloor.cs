using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Event;
using Project;
using UnityEngine;

public class BossWaterFloor : MonoBehaviour
{
    private float defautPosY;
    void Start()
    {
        defautPosY = transform.position.y;
    }

    public void OnBossWaterUpDetected(bool isUp)
    {
        if (isUp)
        {
            transform.DOMoveY(0.65f, 4f).SetEase(Ease.Linear);
        }
        else
        {
            transform.DOMoveY(defautPosY, 3f).SetEase(Ease.Linear);
        }
    }
}
