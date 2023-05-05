using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicLoop : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip musicStart;

    // Start is called before the first frame update
    async void  Start()
    {
        musicSource.Stop();
        
        await Task.Delay(18000);
        
        musicSource.Play();
        musicSource.PlayOneShot(musicStart);
        musicSource.PlayScheduled(AudioSettings.dspTime + musicStart.length);
        
        SceneManager.sceneLoaded += delegate(Scene arg0, LoadSceneMode mode)
        {
            if (arg0.buildIndex == 16)
            {
                Destroy(gameObject);
            }
        };
    }
}