using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatCube : MonoBehaviour
{
    private Vector3 defaultCenter;

    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        defaultCenter = transform.position;

        TryGetComponent(out rigidbody);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , defaultCenter , 0.02f);
    }
}
