using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;
using UnityEngine.Rendering;

public class BossConnonAction : MonoBehaviour
{
    private Transform player;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject bullet;

    public float repeatTime;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AamonAction>().transform;
    }
    
    public void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
