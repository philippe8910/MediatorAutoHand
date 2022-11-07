using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetZone : MonoBehaviour
{
    private LevelSystem _levelSystem;
    
    // Start is called before the first frame update
    void Start()
    {
        _levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _levelSystem.ResetLevelTest();
        }
    }
}
