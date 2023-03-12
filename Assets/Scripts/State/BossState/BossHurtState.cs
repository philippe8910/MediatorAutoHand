namespace State.BossState
{
    public class BossHurtState : IState
    {
        private BossLevelStateManager actor;
        
        public void OnEnterState(object action)
        {
            actor = (BossLevelStateManager) action;
        }

        public void OnStayState(object action)
        {
            actor.StateLoop(2 , new BossIdleState());
        }

        public void OnExitState(object action)
        {
            
        }
    }
}