using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmillaryAnimatorEvent : MonoBehaviour
{
    public GameObject armillaryGameObject;

    public void OnAnimationEnd()
    {
        armillaryGameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
