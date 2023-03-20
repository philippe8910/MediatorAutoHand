using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Footstep Audio Data", menuName = "Audio/Footstep Audio Data")]
public class FootstepAudioData : ScriptableObject
{
    public enum FootstepType
    {
        Glass,
        Sand,
        Ground
    }

    public FootstepType footstepType;
    public float minSpeed = 1f;
    public float maxSpeed = 10f;
    public AudioClip[] grassFootsteps;
    public AudioClip[] woodFootsteps;
    public AudioClip[] concreteFootsteps;

    public AudioClip GetFootstepSound(float speed)
    {
        if (speed >= minSpeed && speed <= maxSpeed)
        {
            AudioClip[] footstepSounds = null;
            switch (footstepType)
            {
                case FootstepType.Glass:
                    footstepSounds = grassFootsteps;
                    break;
                case FootstepType.Sand:
                    footstepSounds = woodFootsteps;
                    break;
                case FootstepType.Ground:
                    footstepSounds = concreteFootsteps;
                    break;
            }
            if (footstepSounds != null && footstepSounds.Length > 0)
            {
                return footstepSounds[Random.Range(0, footstepSounds.Length)];
            }
        }
        return null;
    }
}

