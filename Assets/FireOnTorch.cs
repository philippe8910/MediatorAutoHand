using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireOnTorch : MonoBehaviour
{
    [SerializeField] public Transform torchPoint;
    void Update()
    {
        transform.position = torchPoint.position;
    }
}
