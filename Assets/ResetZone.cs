using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
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
            EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }));
        }
    }
}
