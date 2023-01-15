using UnityEngine;

namespace State
{
    public class StopRunningState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (AamonAction)action;
            
            actor.Animator().CrossFade("StopRunning" , 0.2f);
        }

        public void OnStayState(object action)
        {
            var actor = (AamonAction)action;

            var info = actor.Animator().GetCurrentAnimatorStateInfo(0);
            var currentAnimatorFinish = info.normalizedTime >= 1;
            var isJump = PlayerInputAction.GetJumpActionBoolean();
            var isJoystickInput = PlayerInputAction.JoystickActionInput() != Vector2.zero;
            
            actor.StateListener(new IdleState() , currentAnimatorFinish);
            actor.StateListener(new JumpState() , isJump);
            actor.StateListener(new RunState() , isJoystickInput);
        }

        public void OnExitState(object action)
        {
            
        }
    }
}