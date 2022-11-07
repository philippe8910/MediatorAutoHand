using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_2_Button : LevelEvents
{
    [SerializeField] private GameObject wall;

    [SerializeField] private GameObject endPos;

    [SerializeField] private GameObject soundEffect;
    
    private void Start()
    {
        throw new NotImplementedException();
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        
        endPos.SetActive(true);
        wall.TryGetComponent<Animator>(out var animator);
        
        animator.Play("WallDown");
        
        soundEffect.SetActive(true);
        
        Destroy(this);
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }
}
