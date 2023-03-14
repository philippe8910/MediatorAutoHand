using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawenFracturedObject : MonoBehaviour
{
    public GameObject fracturedObj;

    private CapsuleCollider capCollider;
    private MeshRenderer meshRenderer;
    private bool exploded;
    
    void Start()
    {
        capCollider = GetComponent<CapsuleCollider>();
        meshRenderer = transform.GetChild(0).GetComponent<MeshRenderer>();
    }

    void OnCollisionEnter(Collision co)
    {
        if (capCollider != null && meshRenderer != null)
        {
            if (!exploded)
            {
                if (capCollider.enabled && meshRenderer.enabled && co.gameObject.tag == "Bullet")
                {
                    capCollider.enabled = false;
                    meshRenderer.enabled = false;
                    SpawnFracturedObject();
                }
            }
        }
    }

    public void SpawnFracturedObject()
    {
        exploded = true;
        GameObject fractObj = Instantiate(fracturedObj, transform.position, transform.rotation) as GameObject;
        fracturedObj.GetComponent<ExplodeScript>().Explode();        
    }
}
