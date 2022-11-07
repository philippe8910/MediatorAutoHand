using System;
using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class Level_3_Door : MonoBehaviour
{
    [SerializeField] private LevelEvents button_1, button_2;

    [SerializeField] private Animator animator;

    private void Start()
    {
        TryGetComponent<Animator>(out animator);
    }

    private void Update()
    {
        CheckLevelPass();
    }

    public void CheckLevelPass()
    {
        if (button_1.isEnter && button_2.isEnter)
        {
            animator.Play("LastDoorOpen");
            EventBus.Post(new ChangeScenesDetected(delegate { Debug.Log("Win"); }));
            
            Destroy(button_1);
            Destroy(button_2);
        }
    }
}
