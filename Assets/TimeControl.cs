using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private Animation animation;

    [Range(0 , 2)] public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animation>(out animation);
    }

    private void Update()
    {
        animation[animation.name].time = time;
    }

    public void SetAnimationTime(float value)
    {
        time = value;
    }
}
