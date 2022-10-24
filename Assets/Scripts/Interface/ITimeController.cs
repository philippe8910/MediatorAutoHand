using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITimeController
{
    public float animationTime { get; set; }

    public void OnGrabTime();
    public void OnRotateTime();
    public void OnReleaseTime();
    public void OnFreezeTime();
    public void OnUnfreezeTime();

}
