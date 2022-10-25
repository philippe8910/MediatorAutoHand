using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class PlayerInputAction : MonoBehaviour
{
    [SerializeField] private SteamVR_Action_Boolean jumpActionBoolean;
    [SerializeField] private SteamVR_Action_Vector2 joystickActionVector2;
    [SerializeField] private SteamVR_Action_Boolean interactiveActionBoolean;

    private Camera camera;
    private Transform rightAnchor , forwardAnchor;

    private void Start()
    {
        jumpActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Jump");
        interactiveActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");
        joystickActionVector2 = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Move");
            
        if (!rightAnchor) rightAnchor = transform.GetChild(0);
        if (!forwardAnchor) forwardAnchor = transform.GetChild(1);
        if (!camera) camera = Camera.main;
    }

    public Vector2 JoystickActionInput()
    {
        return joystickActionVector2.axis;
    }

    public Vector2 InputHorizontal()
    {
        return joystickActionVector2.axis.x * (rightAnchor.position - camera.transform.position);
    }
    
    public Vector2 InputVertical()
    {
        return joystickActionVector2.axis.y * (forwardAnchor.position - camera.transform.position);
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
