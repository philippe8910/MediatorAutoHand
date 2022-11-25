using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingRootRotate : MonoBehaviour
{
    public TrailRenderer trailRenderer;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,1);
    }
}
