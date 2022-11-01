using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerInputAction 
{
    [SerializeField] private SteamVR_Action_Boolean jumpActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");
    [SerializeField] private SteamVR_Action_Vector2 joystickActionVector2 = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Move");
    [SerializeField] private SteamVR_Action_Boolean interactiveActionBoolean =  SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");

    public Vector2 JoystickActionInput()
    {
        return joystickActionVector2.axis;
    }
    
    public bool GetJumpActionBoolean()
    {
        return jumpActionBoolean.stateDown;
    }

    public bool GetInteractiveActionBoolean()
    {
        return interactiveActionBoolean.stateDown;
    }
    
}
