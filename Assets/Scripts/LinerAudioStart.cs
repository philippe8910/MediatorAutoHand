using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LinerAudioStart : MonoBehaviour
{
    private AudioSource _audioSource;

    public float maxVolume;

    public float magnification;

    public UnityEvent OnMaxVolume;
    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0;
        StartCoroutine(StartLerp());
    }

    IEnumerator StartLerp()
    {
        if (_audioSource.volume <= maxVolume)
        {
            _audioSource.volume += magnification;
            yield return new WaitForSeconds(0.1f);
            StartCoroutine(StartLerp());
        }
        else
        {
            OnMaxVolume?.Invoke();
        }
    }
    
}
