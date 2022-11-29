using UnityEngine;

namespace State
{
    public class LandingState : IState
    {
        public void OnEnterState(object action)
        {
            var actions = (AamonAction) action;
            
            actions.SetAnimatorCrossState("OnLanding" , 0.01f);

            if(actions.isStateLog) Debug.Log(this.ToString() + " Enter!!");
        }

        public void OnStayState(object action)
        {
            var actions = (AamonAction) action;
            
            var info = actions.Animator().GetCurrentAnimatorStateInfo(0);
            var isPlayEnding = info.normalizedTime >= 1;
            var isMove = PlayerInputAction.JoystickActionInput() != Vector2.zero;
            
            actions.StateListener(new RunState() , isMove);
            actions.StateListener(new IdleState() , isPlayEnding);
        }

        public void OnExitState(object action)
        {
            var actions = (AamonAction) action;
            
            if(actions.isStateLog) Debug.Log(this.ToString() + " Exit!!");
        }
    }
}