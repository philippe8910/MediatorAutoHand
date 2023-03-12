using Enum;
using Event;
using Project;

namespace State.BossState
{
    public class BossWaterAttackState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var attackLoopTime = actor.GetStateDataGroup().CatchAttackTimeData(BossStateEnum.BossFire);
            
            actor.GetAnimator().CrossFade("Attack_0" , 0.1f);
            EventBus.Post(new BossFireDetected(false));
            //actor.InvokeRepeating("CreatAttackCube" , 0 , attackLoopTime);
        }

        public void OnStayState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossFire);
            
            actor.StateLoop(stateTime , new BossWaterAllAttackState());
        }

        public void OnExitState(object action)
        {
            var actor = (BossLevelStateManager) action;
            var nextStateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossFire) + 0.3f;
            
            actor.GetStateDataGroup().SetStateTime(nextStateTime , BossStateEnum.BossFire);
            EventBus.Post(new BossFireDetected(true));
            //actor.CancelInvoke("CreatAttackCube");
        }
    }
}