using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

public class BossLevelStateManager : MonoBehaviour
{
    public BossStateEnum stateEnum;

    public string currentStateTag;

    private IState currentState;


    public void ChangeState(IState newState)
    {
        currentState.OnExitState(this);
        newState.OnEnterState(this);

        currentState = newState;
    }
}
