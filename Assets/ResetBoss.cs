using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ResetBoss : MonoBehaviour
{
    // Start is called before the first frame update
    async void Start()
    {
        await Task.Delay(200);
        
        var playerReset = FindObjectOfType<PlayerResetPosition>();
        
        playerReset.ResetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
