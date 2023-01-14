using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class FloatCube : MonoBehaviour
{
    private Vector3 defaultCenter;

    private Rigidbody rig;

    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rig);
        
        defaultCenter = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(transform.position , defaultCenter , Time.deltaTime * speed);
        rig.velocity = Vector3.Lerp(transform.position , defaultCenter , Time.deltaTime * speed);
    }
    
    
}
