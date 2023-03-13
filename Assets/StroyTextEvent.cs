using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class StroyTextEvent : MonoBehaviour
{
    public void ChangeScene()
    {
        EventBus.Post(new ChangeScenesDetected(delegate
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }));
    }
}
