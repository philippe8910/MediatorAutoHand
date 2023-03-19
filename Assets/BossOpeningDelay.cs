using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class BossOpeningDelay : MonoBehaviour
{
    public float time = 0;
    
    async void  Start()
    {
        await Task.Delay((int)(time * 1000));
        GetComponent<AudioSource>().Play();
    }

}
