using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    private Animation animation;

    [Range(0 , 1)] public float time;
    
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animation>(out animation);
    }

    // Update is called once per frame
    void Update()
    {
        animation[animation.name].time = time;
    }
}
