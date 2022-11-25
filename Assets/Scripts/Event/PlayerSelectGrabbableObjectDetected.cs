using UnityEngine;

namespace Event
{
    public class PlayerSelectGrabbableObjectDetected
    {
        public Transform grabbableTransform;

        public PlayerSelectGrabbableObjectDetected(Transform _transform)
        {
            grabbableTransform = _transform;
        }
    }
}