using Enum;
using Event;
using Project;
using UnityEngine;

namespace State.BossState
{
    public class BossWaterUpState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("WaterUp_0" , 0.1f);
            
            EventBus.Post(new BossWaterUpDetected(true));
        }

        public void OnStayState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossFloodedGround);

            actor.StateLoop(stateTime , new BossWaterFloorAttackState());
        }

        public void OnExitState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var nextStateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossFloodedGround) - 0.2f;
            
            actor.GetStateDataGroup().SetStateTime(nextStateTime , BossStateEnum.BossFloodedGround);
        }
    }
}