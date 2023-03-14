using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Event;
using Project;
using UnityEngine;
using UnityEngine.Rendering;

public class BossConnonAction : MonoBehaviour
{
    private Transform player;

    [SerializeField] private Transform firePoint;

    [SerializeField] private GameObject bullet;

    [SerializeField] private ParticleSystem fireEffect;
    public float repeatTime;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AamonAction>().transform;
        
        fireEffect?.Stop();
    }
    
    public async void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireEffect?.Play();

        await Task.Delay(1000);
        
        fireEffect?.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
