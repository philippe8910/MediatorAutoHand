using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_3_Button : LevelEvents
{
    public override void OnTrigger()
    {
        base.OnTrigger();
    }

    private void OnTriggerStay(Collider other)
    {
        isEnter = true;
    }
}
