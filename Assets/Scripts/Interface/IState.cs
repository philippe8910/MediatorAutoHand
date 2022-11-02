using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnEnterState(object action);

    public void OnStayState(object action);

    public void OnExitState(object action);
}
