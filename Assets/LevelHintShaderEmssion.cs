using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelHintShaderEmssion : MonoBehaviour
{
    [SerializeField] private Material material;

    [SerializeField] private bool isPlay;

    private GameObject player;
    void Start()
    {
        player = FindObjectOfType<AamonAction>().gameObject;
        material.SetFloat("Vector1_186a2e84693943c09de7a0a33c59feb7" , -2);
    }

    void Update()
    {
        if(!isPlay) return;
        
        var dis = Vector3.Distance(transform.position, player.transform.position);
        
        dis = Mathf.Clamp(dis , 0, 1);

        var disLerp = Mathf.Lerp(material.GetFloat("Vector1_186a2e84693943c09de7a0a33c59feb7"), dis - 0.7f, 0.1f);
        
        material.SetFloat("Vector1_186a2e84693943c09de7a0a33c59feb7" , disLerp );
    }

    [Button]
    public void SetGood()
    {
        material.SetFloat("Vector1_186a2e84693943c09de7a0a33c59feb7" , 1);
    }
    
    [Button]
    public void SetBad()
    {
        material.SetFloat("Vector1_186a2e84693943c09de7a0a33c59feb7" , -0.5f);
    }

    public void OpenHint()
    {
        isPlay = true;
    }
}
