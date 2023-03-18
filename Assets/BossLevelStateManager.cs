using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using State.BossState;
using UnityEngine;

public class BossLevelStateManager : MonoBehaviour
{
    [SerializeField] private int hp = 5;
    
    [SerializeField] private float stateTimer;

    [SerializeField] private GamePool gamePool;

    [SerializeField] private BossStateData dataGroup;

    [SerializeField] private List<GameObject> lifeCount = new List<GameObject>();

    private IState currentState = new BossIdleState();

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        currentState.OnStayState(this);

        stateTimer += Time.deltaTime;
    }

    public void Hurt()
    {
        hp--;
        stateTimer = 0;
        lifeCount.ForEach(delegate(GameObject o)
        {
            o.SetActive(false);
        });

        for (int i = 0; i < hp; i++)
        {
            lifeCount[i].SetActive(true);
        }
        ChangeState(new BossHurtState());
    }

    public void CreatAttackWater()
    {
        CreatAttack(BossAttack.WaterFloorAttack);
    }

    public void CreatAttackCube()
    {
        CreatAttack(BossAttack.CubeAttack);
    }

    private void CreatAttack(BossAttack attack)
    {
        switch (attack)
        {
            case BossAttack.WaterFloorAttack:
                var waterAttackPrefab = gamePool.Catch("WaterAttack");
                Instantiate(waterAttackPrefab, waterAttackPrefab.transform.position, waterAttackPrefab.transform.rotation);
                break;
            
            case BossAttack.CubeAttack:
                var cubeAttackPrefab = gamePool.Catch("AttackCube");
                Instantiate(cubeAttackPrefab, cubeAttackPrefab.transform.position, cubeAttackPrefab.transform.rotation);
                break;
        }
    }

    public void StateLoop(float timeMax , IState state)
    {
        if (stateTimer > timeMax)
        {
            ChangeState(state);

            stateTimer = 0;
        }
    }

    public void ChangeState(IState newState)
    {
        currentState.OnExitState(this);
        newState.OnEnterState(this);

        currentState = newState;
    }
    public BossStateData GetStateDataGroup() => dataGroup;
    public Animator GetAnimator() => animator;
}
