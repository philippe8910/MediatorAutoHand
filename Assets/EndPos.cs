using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    [SerializeField] private bool isEnter;

    [SerializeField] private LevelSystem levelSystem;

    private void Start()
    {
        levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isEnter)
        {
            Debug.Log("Level Pass");
            
            isEnter = true;
            levelSystem.LevelChangeTest();
        }
    }
}
