using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using State.BossState;
using UnityEngine;

public class BossStateDebug : MonoBehaviour
{
    [SerializeField]  private BossLevelStateManager bossLevelState;
    
    // Start is called before the first frame update
    void Start()
    {
        bossLevelState = GetComponent<BossLevelStateManager>();
    }
    
    [Button]
    public void IdleState()
    {
        bossLevelState.ChangeState(new BossIdleState());
    }
    
    [Button]
    public void WaterAttackState()
    {
        bossLevelState.ChangeState(new BossWaterAttackState());
    }
    
    [Button]
    public void WaterFloorAttackState()
    {
        bossLevelState.ChangeState(new BossWaterFloorAttackState());
    }
    
    [Button]
    public void WaterUpState()
    {
        bossLevelState.ChangeState(new BossWaterUpState());
    }
    
    [Button]
    public void WaterAllAttackState()
    {
        bossLevelState.ChangeState(new BossWaterAllAttackState());
    }
    
    [Button]
    public void HurtState()
    {
        bossLevelState.ChangeState(new BossHurtState());
    }
    
}
