using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        //animation[animation.name].time = time;
        
        if(!isControl && !isStop) time = Mathf.Lerp(time , 2 , 0.05f);
        if(isControl && !isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);
        if(!isControl && isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);;
        if(isControl && isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);;
    }

    public async void StopTime()
    {
        if (isStop)
        {
            return;
        }
        isStop = true;

        await Task.Delay(5000);

        isStop = false;
    }
    public void SetAnimationTime(float value)
    {
        if(isStop)
            return;
        
        time = value;
    }
}
