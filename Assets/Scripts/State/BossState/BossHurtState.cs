namespace State.BossState
{
    public class BossHurtState : IState
    {
        private BossLevelStateManager actor;
        
        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;
            
            actor.GetAnimator().CrossFade("V_weak_hit_1" , 0.1f);
            
        }

        public void OnStayState(object action)
        {
            actor.StateLoop(3 , new BossHurtEndState());
        }

        public void OnExitState(object action)
        {
            
        }
    }
}