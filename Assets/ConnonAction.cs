using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class ConnonAction : MonoBehaviour
{
    [SerializeField] private bool isLock = true , isReload = false;

    [SerializeField] private UnityEvent OnFireTrigger;

    public ParticleSystem fireEffect;

    private async void Start()
    {
        OnFireTrigger.AddListener(delegate
        {
            IEnumerator StartFireEffect()
            {
                fireEffect.Play();
                yield return new WaitForSeconds(0.5f);
                fireEffect.Stop();
            }

            StartCoroutine(StartFireEffect());
        });
    }

    public void SetLock(bool _isLook)
    {
        isLock = _isLook;
    }

    public void SetReload(bool _isReload)
    {
        isReload = _isReload;
    }

    [Button]
    public void HurtTest()
    {
        OnFireTrigger.Invoke();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Torch"))
        {
            if (!isLock)
            {
                OnFireTrigger.Invoke();
            }
        }
    }
}
