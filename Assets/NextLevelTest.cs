using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class NextLevelTest : MonoBehaviour
{
    public void Next()
    {
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1); }));
    }
}
