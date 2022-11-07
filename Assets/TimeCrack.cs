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
        if (_playerInputAction.GetTriggerBoolean())
        {
            isEnable = !isEnable;
            cracks.SetActive(isEnable);
        }
    }

    private void OnPlayerActionDetected(PlayerActionDetected obj)
    {
        var input = obj.inputActionEnum;

        if (input != PlayerInputActionEnum.Trigger)
            return;

        isEnable = !isEnable;
        cracks.SetActive(isEnable);
    }

    [Button]
    public void TriggerTest()
    {
        EventBus.Post(new PlayerActionDetected(PlayerInputActionEnum.Trigger));
    }
        
}
