namespace State.BossState
{
    public class BossWaterAllAttackState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("Attack_1" , 0.1f);
        }

        public void OnStayState(object action)
        {
            var actor = (BossLevelStateManager) action;
        }

        public void OnExitState(object action)
        {
            var actor = (BossLevelStateManager) action;
        }
    }
}