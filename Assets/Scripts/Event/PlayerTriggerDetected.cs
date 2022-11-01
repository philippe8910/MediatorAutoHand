using Enum;

namespace Event
{
    public class PlayerTriggerDetected
    {
        public PlayerInputActionEnum playerInputAction;

        public PlayerTriggerDetected(PlayerInputActionEnum input)
        {
            playerInputAction = input;
        }
    }
}