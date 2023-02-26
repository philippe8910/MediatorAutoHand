using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacingPlayer : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        try
        {
            transform.LookAt(new Vector3(Camera.main.transform.position.x , transform.position.y , Camera.main.transform.position.z));
        }
        catch (Exception e)
        {
            Destroy(this);
            Console.WriteLine(e);
            throw;
        }    
    }
}
