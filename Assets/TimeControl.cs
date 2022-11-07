using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private Animation animation;

    [Range(0 , 2)] public float time;

    [SerializeField] public bool isControl;

    [SerializeField] public bool isStop;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animation>(out animation);
    }

    private void Update()
    {
        animation[animation.name].time = time;
    }

    public void StopTime()
    {
        isStop = true;
    }
    public void SetAnimationTime(float value)
    {
        if(isStop)
            return;
        
        time = value;
    }
}
