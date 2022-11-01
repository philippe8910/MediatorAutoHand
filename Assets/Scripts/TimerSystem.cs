using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public static Dictionary<float, Action> timeInvoker = new Dictionary<float, Action>();

    public static void AddTimerAction(float delay , Action action)
    {
        timeInvoker.Add(Time.time + delay , action);
    }

    private void Start()
    {
        AddTimerAction(3 , delegate { Debug.Log("VR"); });
    }

    private void Update()
    {
        var timerSelectList = timeInvoker.Where(delay => Time.time > delay.Key).ToList();

        if (timerSelectList.Count != 0)
        {
            timerSelectList.ForEach(t => t.Value.Invoke());
            timerSelectList.ForEach(t => timeInvoker.Remove(t.Key));

            //Debug.Log(timeInvoker.Count);
        }
    }
}
