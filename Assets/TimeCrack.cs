using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class TimeCrack : MonoBehaviour
{
    private bool isEnable;
    
    private GameObject cracks;

    private PlayerInputAction _playerInputAction = new PlayerInputAction();
    
    // Start is called before the first frame update
    void Start()
    {
        //EventBus.Subscribe<PlayerActionDetected>(OnPlayerActionDetected);

        cracks = transform.GetChild(0).gameObject;
    }

    private void Update()
    {

    }
    
    [Button]
    public void TriggerTest()
    {
        EventBus.Post(new PlayerActionDetected(PlayerInputActionEnum.Trigger));
    }
        
}
