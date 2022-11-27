using System.Collections;
using System.Collections.Generic;
using Interface;
using UnityEngine;

public class TestTask : MonoBehaviour , ITask
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Test()
    {
        taskComplete = true;
        
    }
    
    public bool taskComplete { get; set; }
}
