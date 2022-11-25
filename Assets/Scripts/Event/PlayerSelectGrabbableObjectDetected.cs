using UnityEngine;

namespace Event
{
    public class PlayerSelectGrabbableObjectDetected
    {
        public GrabbableCustom grabbableTransform;

        public PlayerSelectGrabbableObjectDetected(GrabbableCustom _transform)
        {
            grabbableTransform = _transform;
        }
    }
}