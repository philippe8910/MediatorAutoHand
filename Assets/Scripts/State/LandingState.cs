using UnityEngine;

namespace State
{
    public class LandingState : IdleState
    {
        public override void OnEnterState(object action)
        {
            var actions = (AamonAction) action;
            
            actions.SetAnimatorCrossState("OnLanding" , 0.1f);
            
            if(actions.isStateLog) Debug.Log(this.ToString() + " Enter!!");
        }

        public override void OnStayState(object action)
        {
            var actions = (AamonAction) action;
            
            base.OnStayState(action);
        }

        public override void OnExitState(object action)
        {
            var actions = (AamonAction) action;
            
            if(actions.isStateLog) Debug.Log(this.ToString() + " Exit!!");
        }
    }
}