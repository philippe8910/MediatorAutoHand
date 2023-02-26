using UnityEngine;

namespace State
{
    public class DazeState : IdleState
    {
        public override void OnEnterState(object action)
        {
            var actions = (AamonAction) action;
        
            actions.SetAnimatorCrossState("Sad Idle" , 0.5f);

            if(actions.isStateLog) Debug.Log("Sad Idle Enter!!");
        }
    }
}