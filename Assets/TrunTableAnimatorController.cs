using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunTableAnimatorController : MonoBehaviour
{
    private Animator animation;

    [Range(0 , 2)] public float time;

    public bool isEnterArea;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animator>(out animation);
    }

    private void Update()
    {
        if (isEnterArea)
        {
            animation.CrossFade("Rotate" , 0.2f);
        }
        
        animation.SetFloat("Time" , time / 2);
        
        //if(!isControl && !isStop) time = Mathf.Lerp(time , 2 , 0.05f);
        //if(isControl && !isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);
        //if(!isControl && isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);;
        //if(isControl && isStop) animation[animation.name].time = Mathf.Lerp(animation[animation.name].time , time , 1f);;
    }
    
    public void SetAnimationTime(float value)
    {
        time = value;
    }
}
