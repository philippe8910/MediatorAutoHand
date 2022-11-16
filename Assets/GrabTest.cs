using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class GrabTest : HandDistanceGrabber
{
    public override void Start()
    {
        base.Start();
        StartPointing();
    }

    public override void StopPointing()
    {
        
    }
}
