using System.Collections;
using System.Collections.Generic;
using Autohand;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class CameraAction : MonoBehaviour
{
    [SerializeField] private Camera photoCamera;
    
    [SerializeField] private bool isGrab;

    //[SerializeField] private Image photograph;

    [SerializeField] private GameObject photograph;

    [SerializeField] private Transform createPhotoPos;

    [SerializeField] private AudioSource shutterClickSound;
    
    [Button]
    public void TakePhoto()
    {
        if (isGrab)
        {
            var takePhoto = RTImage(photoCamera);

            //photograph.sprite = Sprite.Create(takePhoto , new Rect(0 , 0 , takePhoto.width , takePhoto.height) , new Vector2(0,0));
            var photo = Instantiate(photograph, createPhotoPos.position, createPhotoPos.transform.rotation);
            var photoImage = photo.transform.GetChild(0).gameObject;
            var photoRig = photo.GetComponent<Rigidbody>();
            var photoGrabbable = photo.GetComponent<Grabbable>();

            var image = photoImage.GetComponent<MeshRenderer>();

            image.material.SetTexture("_BaseMap", takePhoto);
            shutterClickSound.Play();
        }
    }

    Texture2D RTImage(Camera camera)
    {
        var currentRT = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;
        
        camera.Render();
        
        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height , TextureFormat.RGB24, false, true);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();
        
        RenderTexture.active = currentRT;
        return image;
    }
    


    public void SetGrabbable(bool _isGrab)
    {
        isGrab = _isGrab;
    }
}
