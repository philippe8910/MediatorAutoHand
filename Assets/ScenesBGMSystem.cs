using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScenesBGMSystem : MonoBehaviour
{
    [SerializeField] private AudioSource intro, loop;

    // Update is called once per frame
    void Update()
    {
        if (!intro.isPlaying)
        {
            loop.Play();
            Destroy(this);
        }
    }
}
