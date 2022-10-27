using UnityEngine;

namespace State
{
    public class LandingState : IState
    {
        public void OnEnterState(object action)
        {
            var actions = (AamonAction) action;
            
            actions.SetAnimatorCrossState("OnLanding" , 0.1f);
            
            if(actions.isStateLog) Debug.Log("Landing Enter!!");
        }

        public void OnStayState(object action)
        {
            var actions = (AamonAction) action;
            
            if(actions.isStateLog) Debug.Log("Landing Stay!!");
        }

        public void OnExitState(object action)
        {
            var actions = (AamonAction) action;
            
            if(actions.isStateLog) Debug.Log("Landing Exit!!");
        }
    }
}