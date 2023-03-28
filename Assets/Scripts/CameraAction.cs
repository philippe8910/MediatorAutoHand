using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    [SerializeField] private List<GameObject> catchObjects = new List<GameObject>();

    public LayerMask layerMask;
    
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
            var photoText = photo.transform.GetChild(1).transform.GetChild(1).GetComponent<Text>();

            var image = photoImage.GetComponent<MeshRenderer>();
            
            var allObjectInRender = FindObjectsOfType<CameraRenderDetecter>();

            for (int i = 0; i < allObjectInRender.Length; i++)
            {
                if (allObjectInRender[i].isVisible)
                {
                    photoText.text = allObjectInRender[i].introduce;
                    i = 100;
                }
            }

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
    
    private bool IsObjectVisibleInCamera(GameObject go, Camera camera)
    {
        Renderer renderer = go.GetComponent<Renderer>();
        
        if (renderer != null && renderer.isVisible) // 如果該物件有 Renderer 且可見
        {
            Vector3 screenPos = camera.WorldToViewportPoint(renderer.bounds.center); // 將物件的中心點轉換為 Viewport 坐標系
            if (screenPos.z > 0 && screenPos.x > 0 && screenPos.x < 1 && screenPos.y > 0 && screenPos.y < 1) // 如果物件在相機的視野範圍內
            {
                return true;
            }
        }
        return false;
    }
}
