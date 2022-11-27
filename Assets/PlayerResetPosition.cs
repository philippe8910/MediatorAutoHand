using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using Valve.VR;

public class PlayerResetPosition : MonoBehaviour
{

    [SerializeField] private Transform resetTransform;

    [SerializeField] private GameObject player;

    [SerializeField] private Camera playerHead;

    [Button]
    public void ResetPosition()
    {
        var rotationAngleY = resetTransform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        var distanceDiff = resetTransform.position - playerHead.transform.position;

        player.transform.Rotate(0 , rotationAngleY , 0);
        player.transform.position += distanceDiff;

    }
}
