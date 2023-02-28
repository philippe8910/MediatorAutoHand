using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
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

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = FindObjectOfType<AamonAction>();
            
            player.ChangeState(new DrownState());

            await Task.Delay(1000);
            
            EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }));
        }
    }
}
