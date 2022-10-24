using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGrabbable
{
    void Grab(object action);
    void UnGrab(object action);
    void OnGrab(object action);
    void DisGrab(object action);
}
