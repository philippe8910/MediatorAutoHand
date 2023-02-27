using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_1_4_Task : MonoBehaviour
{
    [SerializeField] private bool _levelEvents_1, _levelEvents_2;

    [SerializeField] private UnityEvent OnLevelPass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_levelEvents_1 && _levelEvents_2)
        {
            OnLevelPass.Invoke();
            //Destroy(gameObject);
        }
    }

    public void SetEvent_1(bool isEnter)
    {
        _levelEvents_1 = isEnter;
    }

    public void SetEvent_2(bool isEnter)
    {
        _levelEvents_2 = isEnter;
    }
}
