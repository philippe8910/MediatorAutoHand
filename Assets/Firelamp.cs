using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Firelamp : MonoBehaviour
{
    [SerializeField] private bool isEnter;

    private Animator animator;

    private Level_4_Task taskManager;

    public bool isFire;

    public bool isRight;

    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Animator>(out animator);

        taskManager = FindObjectOfType<Level_4_Task>();
    }
    
    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Troch"))
        {
            animator.Play("FireOn");
            isFire = true;
            taskManager.TaskAdd(this);
        }
    }

    public void SetIsFire(bool value)
    {
        isFire = value;

        if (!isFire)
        {
            taskManager.TaskRemove(this);
        }
    }
}
