using Enum;

namespace State.BossState
{
    public class BossWeakState : IState
    {
        private BossLevelStateManager actor;
        
        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;
            actor.GetAnimator().CrossFade("V_weak_idel_1" , 0.3f);
        }

        public void OnStayState(object action)
        {
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossRest);
            
            actor.StateLoop(stateTime , new BossIdleState());
        }

        public void OnExitState(object action)
        {
            
        }
    }
}