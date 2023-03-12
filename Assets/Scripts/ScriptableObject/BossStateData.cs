using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

[CreateAssetMenu(fileName = "BossStateData", menuName = "BossStateData", order = 0)]
public class BossStateData : ScriptableObject
{
    public List<BossStateDataGroup> dataGroups = new List<BossStateDataGroup>();

    public void SetStateTime(float time , BossStateEnum stateEnum)
    {
        dataGroups.ForEach(delegate(BossStateDataGroup group)
        {
            if (group.stateName == stateEnum)
            {
                group.stateTime = time;
            }
        });
    }

    public float CatchTimeData(BossStateEnum stateEnum)
    {
        float time = 0;
        
        dataGroups.ForEach(delegate(BossStateDataGroup group)
        {
            if (group.stateName == stateEnum)
            {
                time = group.stateTime;
            }
        });

        return time;
    }

    public float CatchAttackTimeData(BossStateEnum stateEnum)
    {
        float time = 0;
        
        dataGroups.ForEach(delegate(BossStateDataGroup group)
        {
            if (group.stateName == stateEnum)
            {
                time = group.attackLoopTime;
            }
        });

        return time;
    }
}

[System.Serializable]
public class BossStateDataGroup
{
    public BossStateEnum stateName;

    public float stateTime;

    public float attackLoopTime;
}
