using Enum;

namespace State.BossState
{
    public class BossWaterFloorAttackState : IState
    {
        private BossLevelStateManager actor;

        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;

            var attackLoopTime = actor.GetStateDataGroup().CatchAttackTimeData(BossStateEnum.BossGroundAttack);
            
            actor.GetAnimator().CrossFade("Attack_1" , 0.1f);
            actor.InvokeRepeating("CreatAttackWater" , 0 , attackLoopTime);
        }

        public void OnStayState(object action)
        {
            var stateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossGroundAttack);
            
            actor.StateLoop(stateTime , new BossWaterAttackState());
        }

        public void OnExitState(object action)
        {
            var nextStateTime = actor.GetStateDataGroup().CatchTimeData(BossStateEnum.BossGroundAttack) + 0.2f;
            
            actor.GetStateDataGroup().SetStateTime(nextStateTime , BossStateEnum.BossGroundAttack);
            actor.CancelInvoke("CreatAttackWater");
        }

    }
}