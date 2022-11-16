using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class DontDestroyScript : MonoBehaviour
{
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    [Button]
    public void SwitchScenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }

}
