using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class TimeDial : PhysicsGadgetHingeAngleReader
{
    private Grabbable grabbable;
    
    [SerializeField] private TimeControl targetTimeController;

    [SerializeField] private ArmillaryAction timeController;
    
    // Start is called before the first frame update
    new protected void Start()
    {
        base.Start();

        TryGetComponent<Grabbable>(out grabbable);
        
        if(!targetTimeController) Debug.LogError(this.name + "Time Controller is empty!!");
        
        grabbable.onGrab.AddListener(delegate(Hand arg0, Grabbable grabbable1)
        {
            targetTimeController.isControl = true;
            timeController.OnGrab.Invoke();
        });
        
        
        grabbable.onRelease.AddListener(delegate(Hand arg0, Grabbable grabbable1)
        {
            targetTimeController.isControl = false;
            timeController.OnRelease.Invoke();
        });
    }

    // Update is called once per frame
    void Update()
    {
        targetTimeController?.SetAnimationTime(GetValue() + 1);
        timeController?.SetAnimationTime(GetValue() + 1);
    }
}
