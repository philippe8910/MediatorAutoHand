using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public Vector3 targetPosition;
    
    public Vector3 targetVector3;
    
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = FindObjectOfType<AamonAction>().transform.position;
        transform.LookAt(targetPosition);

        targetVector3 = transform.position - targetPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= targetVector3 * Time.deltaTime;
        
        Destroy(gameObject , 5);
    }
}
