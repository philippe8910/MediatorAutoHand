using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPoint : MonoBehaviour
{
    [SerializeField] private PlayerResetPosition resetPosition;

    [SerializeField] private Transform cam;
    
    void Start()
    {
        resetPosition = FindObjectOfType<PlayerResetPosition>();
        cam = transform.GetChild(0);
        
        Destroy(cam.gameObject);
        resetPosition.ResetPosition();
        
    }
}
