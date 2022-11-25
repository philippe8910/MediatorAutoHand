using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class GrabRobot : MonoBehaviour
{
    [SerializeField] private Transform ringPos;

    [SerializeField] private Transform target;

    [SerializeField] private int index;
    
    // Start is called before the first frame update
    void Start()
    {
        EventBus.Subscribe<PlayerSelectGrabbableObjectDetected>(OnPlayerSelectGrabbableObjectDetected);
    }

    private void OnPlayerSelectGrabbableObjectDetected(PlayerSelectGrabbableObjectDetected obj)
    {
        var grabbableCustom = obj.grabbableTransform;

        if (grabbableCustom != null)
        {
            target = grabbableCustom.GetIndexVector(index);
        }
        else
        {
            target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.position = Vector3.Lerp(transform.position , target.position , 0.1f);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position , ringPos.position , 0.1f);
        }
    }
}
