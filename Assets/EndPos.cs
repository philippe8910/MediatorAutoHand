using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class EndPos : MonoBehaviour
{
    [SerializeField] private bool isEnter;

    //[SerializeField] private LevelSystem levelSystem;

    private void Start()
    {
        //levelSystem = FindObjectOfType<LevelSystem>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isEnter)
        {
            Debug.Log("Level Pass");
            
            isEnter = true;
            EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1); }));
            
            Destroy(gameObject);
        }
    }
}
