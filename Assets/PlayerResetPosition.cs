using System;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Valve.VR;

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
    
    public void ResetLevel()
    {
        EventBus.Post(new ChangeScenesDetected(delegate { UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex); }));
    }

    [Button]
    public void JoystickVibration()
    {
        PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.RightHand , 5);
        PlayerInputAction.JoyStickVibration(SteamVR_Input_Sources.LeftHand , 5);
    }
}
