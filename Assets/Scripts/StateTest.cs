using System;
using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using State;
using UnityEngine;

public class StateTest : MonoBehaviour
{
    public AamonAction action;

    private void Start()
    {
        TryGetComponent<AamonAction>(out action);
    }

    [Button]
    public void RunState()
    {
        action.ChangeState(new RunState());
    }
    
    [Button]
    public void IdleState()
    {
        action.ChangeState(new IdleState());
    }
    
    [Button]
    public void JumpState()
    {
        action.ChangeState(new JumpState());
    }
    
    [Button]
    public void FallingState()
    {
        action.ChangeState(new FallingState());
    }
    
    [Button]
    public void LandingState()
    {
        action.ChangeState(new LandingState());
    }
    
}
