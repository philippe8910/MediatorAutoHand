using Enum;
using Event;
using Project;
using UnityEngine;
using Valve.VR;

public class PlayerInputAction 
{
    public static SteamVR_Action_Vector2 joystickActionVector2 = SteamVR_Input.GetAction<SteamVR_Action_Vector2>("Move");

    public static SteamVR_Action_Boolean triggerActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("GrabPinch");
    public static SteamVR_Action_Boolean jumpActionBoolean = SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Brake");
    public static SteamVR_Action_Boolean interactiveActionBoolean =  SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Reset");

    public static Vector2 JoystickActionInput()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.InputJoystick));
        return new Vector2(joystickActionVector2.axis.x , joystickActionVector2.axis.y);
    }
    
    public static bool GetJumpActionBoolean()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Jump));
        return jumpActionBoolean.stateDown;
    }

    public static bool GetTriggerBoolean()
    {
        EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Trigger));
        return triggerActionBoolean.stateDown;
    }

    public static bool GetInteractiveActionBoolean()
    {
        return interactiveActionBoolean.stateDown;
    }
    
}
