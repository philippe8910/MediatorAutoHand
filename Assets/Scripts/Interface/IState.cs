using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState
{
    public void OnEnterState(CharacterStateAction action);

    public void OnStayState(CharacterStateAction action);

    public void OnExitState(CharacterStateAction action);

}
