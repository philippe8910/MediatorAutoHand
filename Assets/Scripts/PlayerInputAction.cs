using Enum;
using Event;
using Project;
using UnityEngine;
using Valve.VR;

public class PlayerInputAction 
{
    private SteamVR_Action_Vector2 joystickActionVector2 = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Move");

    private SteamVR_Action_Boolean triggerActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    private SteamVR_Action_Boolean jumpActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");
    private SteamVR_Action_Boolean interactiveActionBoolean =  SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");

    public Vector2 JoystickActionInput()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.InputJoystick));
        return joystickActionVector2.axis;
    }
    
    public bool GetJumpActionBoolean()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Jump));
        return jumpActionBoolean.stateDown;
    }

    public bool GetTriggerBoolean()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Trigger));
        return triggerActionBoolean.stateDown;
    }

    public bool GetInteractiveActionBoolean()
    {
        return interactiveActionBoolean.stateDown;
    }
    
}
