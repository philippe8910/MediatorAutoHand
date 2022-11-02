using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginningLogo : MonoBehaviour
{
    public GameObject target;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , target.transform.position , 0.1f);
        transform.LookAt(Camera.main.transform);

       
    }

    public void ChangeScenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
