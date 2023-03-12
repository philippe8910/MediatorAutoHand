using Enum;
using UnityEngine;

namespace State.BossState
{
    public class BossIdleState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("Idle" , 0.1f);
        }

        public void OnStayState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossIdle);

            actor.StateLoop(stateTime  , new BossWaterUpState());
        }

        public void OnExitState(object action)
        {
            var actor = (BossLevelStateManager)action;
            var nextStateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossIdle) - 0.2f;
            
            actor.GetStateDataGroup().SetStateTime(nextStateTime , BossStateEnum.BossIdle);
        }
    }
}