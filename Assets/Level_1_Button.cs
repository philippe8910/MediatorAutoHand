using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_1_Button : LevelEvents
{
    public Animator doorAnimator;

    private void Start()
    {
        TryGetComponent<Animator>(out doorAnimator);
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        
    }

    public override void OnRelease()
    {
        base.OnRelease();
        
    }
}
