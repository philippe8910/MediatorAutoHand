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

    [SerializeField] private GameObject fireLine;

    [SerializeField] private ParticleSystem fireEffect;
    public float repeatTime;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AamonAction>().transform;
        
        fireEffect?.Stop();
        fireLine.SetActive(false);
    }
    
    public async void Fire()
    {
        fireLine.SetActive(false);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        
        fireEffect?.Play();

        await Task.Delay(1000);
        
        fireEffect?.Stop();
    }

    public void Aim()
    {
        fireLine.SetActive(true);
    }

    public void DisAim()
    {
        fireLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
