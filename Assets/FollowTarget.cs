using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public GameObject target;

    public Animator animator;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position , target.transform.position , 0.1f);
        transform.LookAt(Camera.main.transform);

        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1)
        {
            Destroy(player);
            ChangeScenes();
        }
    }

    public void ChangeScenes()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
