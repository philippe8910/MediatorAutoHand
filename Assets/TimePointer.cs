using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimePointer : MonoBehaviour
{
    public float pointRange;
    
    public Transform forwardPointer;

    public LayerMask layers;
    
    RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        bool didHit = Physics.SphereCast(forwardPointer.position, pointRange, forwardPointer.forward, out hit, 100, layers);

        if (didHit)
        {
            Debug.Log("Time Get!!!");
        }
    }
}
