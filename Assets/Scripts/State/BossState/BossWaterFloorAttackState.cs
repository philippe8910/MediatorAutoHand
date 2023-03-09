namespace State.BossState
{
    public class BossWaterFloorAttackState : IState
    {
        public void OnEnterState(object action)
        {
            var actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("Idle" , 0.1f);
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