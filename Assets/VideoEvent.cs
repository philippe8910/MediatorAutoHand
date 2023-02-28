using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Video;

public class VideoEvent : MonoBehaviour
{
    public UnityEvent OnVideoEnd;

    [SerializeField] private VideoPlayer _videoPlayer; 
    
    // Start is called before the first frame update
    void Start()
    {
        _videoPlayer = GetComponent<VideoPlayer>();
        
        _videoPlayer.loopPointReached += delegate(VideoPlayer source)
        {
            OnVideoEnd.Invoke();
        };
    }
    
    
}
