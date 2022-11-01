using Enum;

namespace Event
{
    public class PlayerActionDetected
    {
        public PlayerInputActionEnum inputActionEnum;

        public PlayerActionDetected(PlayerInputActionEnum playerInputActionEnum)
        {
            inputActionEnum = playerInputActionEnum;
        }
    }
}