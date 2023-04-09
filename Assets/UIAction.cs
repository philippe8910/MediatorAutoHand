using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class UIAction : MonoBehaviour
{
    [SerializeField] private Transform cameraAnchor;

    [SerializeField] private GameObject boardBackground;

    [SerializeField] private Material tutorialMaterial, gameMaterial;

    private bool isOpen = false;

    private GameObject uiObject;
    
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        uiObject = transform.GetChild(0).gameObject;
        
        OnUIDisable();
    }

    private void Update()
    {
        if (PlayerInputAction.GetUIOpenBoolean())
        {
            isOpen = !isOpen;

            if (isOpen)
            {
                OnUIEnable();
            }
            else
            {
                OnUIDisable();
            }
        }
    }
    
    [Button]
    public void OnUIEnable()
    {
        uiObject.SetActive(true);
        
        var mainCameraTransform = Camera.main.transform;
        var targetVector = new Vector3(cameraAnchor.position.x , transform.position.y , cameraAnchor.position.z);
                     
        transform.position = targetVector;
        transform.LookAt(new Vector3(mainCameraTransform.position.x , transform.position.y , mainCameraTransform.position.z));
    }

    [Button]
    public void OnUIDisable()
    {
        uiObject.SetActive(false);
    }

    [Button]
    public void SetInGameMaterial()
    {
        boardBackground.GetComponent<MeshRenderer>().material = gameMaterial;
    }

    [Button]
    public void SetInTutorialMaterial()
    {
        boardBackground.GetComponent<MeshRenderer>().material = tutorialMaterial;
    }
}
