using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;
using UnityEngine.Rendering;

public class BossConnonAction : MonoBehaviour
{
    private Transform player;

    [SerializeField] private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<AamonAction>().transform;
        
        EventBus.Subscribe<BossFireDetected>(OnBossFireDetected);
    }

    private void OnBossFireDetected(BossFireDetected obj)
    {
        if (obj.isStop)
        {
            CancelInvoke("Fire");
        }
        else
        {
            InvokeRepeating("Fire" , 0 , 0.4f);
        }
    }

    public void Fire()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
    }
}
