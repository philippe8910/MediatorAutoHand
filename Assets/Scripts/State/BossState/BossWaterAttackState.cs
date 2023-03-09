namespace State.BossState
{
    public class BossWaterAttackState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("Attack_0" , 0.1f);
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