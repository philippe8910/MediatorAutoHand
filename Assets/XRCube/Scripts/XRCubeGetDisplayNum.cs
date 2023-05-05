using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XRCubeGetDisplayNum : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject dis;
    void Start()
    {
        
    }
    int a = 0;
    // Update is called once per frame
    void Update()
    {
        a = dis.GetComponent<Camera>().targetDisplay;
        this.GetComponent<Text>().text = "Dis_"+(a+1);
    }
}
