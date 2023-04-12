using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Photograph : MonoBehaviour
{
    private bool isGrab;
    
    private async void Start()
    {
        SceneManager.activeSceneChanged += delegate(Scene arg0, Scene scene)
        {
            Destroy(gameObject);
        };
        
        await Task.Delay(3000);
        
        if(isGrab == false)
            Destroy(gameObject);
    }

    public void OnGrab()
    {
        isGrab = true;
    }
}
