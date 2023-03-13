namespace State.BossState
{
    public class BossHurtEndState : IState
    {
        private BossLevelStateManager actor;
        
        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("V_weak_end" , 0.1f);
        }

        public void OnStayState(object action)
        {
            actor.StateLoop(3 , new BossIdleState());
        }

        public void OnExitState(object action)
        {
            
        }
    }
}