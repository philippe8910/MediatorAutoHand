using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRCube_CameraSetting : MonoBehaviour
{
    public XRCubeUDP setting;
    void Start()
    {
        if (setting == null)
            transform.GetChild(0).TryGetComponent(out setting);

        setting.XRCam = Camera.main.transform.gameObject;
    }
    
}
