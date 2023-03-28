using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Events;

public class CameraRenderDetecter : MonoBehaviour
{
    public bool isVisible;
    
    public string introduce;

    public Camera targetCamera;

    private Plane[] cameraFrustum;

    private Bounds bounds;

    private void Start()
    {
        bounds = GetComponent<Collider>().bounds;
    }

    private void Update()
    {
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(targetCamera);

        if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            isVisible = true;
        }
        else
        {
            isVisible = false;
        }
    }

}
