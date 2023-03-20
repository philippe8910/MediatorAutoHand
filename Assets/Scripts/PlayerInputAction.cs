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
    
    public static SteamVR_Action_Boolean resetPositionBoolean =  SteamVR_Input.GetAction<SteamVR_Action_Boolean>("Jump");

    public static SteamVR_Action_Vibration hapticActionVibration = SteamVR_Input.GetAction<SteamVR_Action_Vibration>("Haptic");

    public static Vector2 JoystickActionInput()
    {
        //EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.InputJoystick));
        //return new Vector2(joystickActionVector2.axis.x , joystickActionVector2.axis.y);
        
        return new Vector2(0.1f , 0);
    }
    
    public static bool GetJumpActionBoolean()
    {
        //EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Jump));
        return jumpActionBoolean.stateDown;
    }

    public static bool GetTriggerBoolean()
    {
        //EventBus.Post(new PlayerTriggerDetected(PlayerInputActionEnum.Trigger));
        return triggerActionBoolean.stateDown;
    }

    public static bool GetInteractiveActionBoolean()
    {
        return interactiveActionBoolean.stateDown;
    }

    public static bool GetResetPositionBoolean()
    {
        return resetPositionBoolean.stateDown;
    }

    public static void JoyStickVibration(SteamVR_Input_Sources hand , float tick)
    {
        if (hand == SteamVR_Input_Sources.RightHand)
        {
            hapticActionVibration.Execute(0,tick ,10,10,hand);
        }

        if (hand == SteamVR_Input_Sources.LeftHand)
        {
            hapticActionVibration.Execute(0,tick ,10,10,hand);
        }
    }
    
}
