using System;
using Sirenix.OdinInspector;
using UnityEngine;

public class PlayerResetPosition : MonoBehaviour
{
    [SerializeField] private Transform resetTransform;

    [SerializeField] private GameObject player;

    [SerializeField] private Camera playerHead;
    

    [Button]
    public void ResetPosition()
    {
        try
        {
            var rotationAngleY = resetTransform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        
            player.transform.Rotate(0 , rotationAngleY , 0);
        
            var distanceDiff = resetTransform.position - playerHead.transform.position;
        
            player.transform.position += distanceDiff;
        }
        catch (Exception e)
        {
            resetTransform = GameObject.FindWithTag("ResetPosition").transform;
            
            var rotationAngleY = resetTransform.rotation.eulerAngles.y - playerHead.transform.rotation.eulerAngles.y;
        
            player.transform.Rotate(0 , rotationAngleY , 0);
        
            var distanceDiff = resetTransform.position - playerHead.transform.position;
        
            player.transform.position += distanceDiff;
            
            throw;
        }

    }
}
