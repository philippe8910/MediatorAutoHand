using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class TimeDial : PhysicsGadgetHingeAngleReader
{
    private Grabbable grabbable;
    
    [SerializeField] private TimeControl targetTimeController;
    
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();
        if(!targetTimeController) Debug.LogError(this.name + "Time Controller is empty!!");
    }

    // Update is called once per frame
    void Update()
    {
        targetTimeController.SetAnimationTime(GetValue() + 1);
    }
}
