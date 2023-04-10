using Enum;
using Event;
using Project;

namespace State.BossState
{
    public class BossWaterAllAttackState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetBossWaterFloor().OnBossWaterUpDetected(false);
            actor.GetAnimator().CrossFade("WaterUp_1" , 0.1f);
        }

        public void OnStayState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossAllAttack);
            
            actor.StateLoop(stateTime , new BossWeakState());
        }

        public void OnExitState(object action)
        {
            var actor = (BossLevelStateManager) action;
        }
    }
}