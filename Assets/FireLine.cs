using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLine : MonoBehaviour
{
    public LineRenderer renderer;

    public Transform startPoint , endPoint;
    
    public void Update()
    {
        renderer.SetPosition(0 ,  startPoint.position);
        renderer.SetPosition(1 , endPoint.transform.position);
    }
}
