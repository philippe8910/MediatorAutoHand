using Event;
using Project;

namespace State.BossState
{
    public class BossDeadState : IState
    {
        private BossLevelStateManager actor;
        
        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("V_weak_idel_1" , .1f);
            
            EventBus.Post(new OnEnableLevelHintDetected("阿薩斯龍語...真的好強..."));
        }

        public void OnStayState(object action)
        {
            
        }

        public void OnExitState(object action)
        {
            
        }
    }
}