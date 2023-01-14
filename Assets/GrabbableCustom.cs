using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using Event;
using Project;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody) , typeof(Grabbable) , typeof(DistanceGrabbable))]
public class GrabbableCustom : MonoBehaviour
{
    [SerializeField] private GameObject cube;
    
    private bool isGrab;
    
    private Grabbable _grabbable;

    public List<Transform> robotPoint = new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Grabbable>(out _grabbable);
        TryGetComponent<DistanceGrabbable>(out var _distanceGrabbable);
        
        _grabbable.OnHighlightEvent += delegate(Hand hand, Grabbable grabbable)
        {
            EventBus.Post(new PlayerSelectGrabbableObjectDetected(this)); 
        };
        
        _grabbable.OnUnhighlightEvent += delegate(Hand hand, Grabbable grabbable)
        {
            EventBus.Post(new PlayerSelectGrabbableObjectDetected(null)); 
        };
        
        _grabbable.onGrab.AddListener(delegate(Hand arg0, Grabbable grabbable)
        {
            isGrab = true;
        });
        
        _distanceGrabbable.OnPull.AddListener(delegate(Hand arg0, Grabbable grabbable)
        {
            OnStartPull();
        });
    }

    public Transform GetIndexVector(int index)
    {
        return robotPoint[index];
    }

    public void OnStartPull()
    {
        isGrab = false;

        TryGetComponent(out Rigidbody rig);
        
        rig.AddTorque(new Vector3(0.1f , 0.1f, 0.1f));
        
        StartCoroutine(StartPull());
        
        IEnumerator StartPull()
        {
            if (!isGrab)
            {
                var g = Instantiate(cube, transform.position, transform.rotation);
                 
                
                Destroy(g , 0.55f);
                yield return new WaitForSeconds(0.01f);
                StartCoroutine(StartPull());
            }
            else
            {
                yield return null;
            }
        }
    }
    
}

/*
                var material = g.GetComponent<MeshRenderer>().material;

                Material newMaterial = material;

                newMaterial.color = new Color(newMaterial.color.r + 0.01f, newMaterial.color.g,
                    newMaterial.color.b + 0.01f);
                g.GetComponent<MeshRenderer>().material = newMaterial;
*/