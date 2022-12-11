using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level_4_Task : MonoBehaviour
{
    [SerializeField] private List<Firelamp> task = new List<Firelamp>();

    [SerializeField] private UnityEvent OnTaskEnd;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (task.Count == 3)
        {
            if (task[0].isRight && task[1].isRight && task[2].isRight)
            {
                OnTaskEnd?.Invoke();
            }
        }
    }

    public void TaskAdd(Firelamp value)
    {
        task.Add(value);
    }

    public void TaskRemove(Firelamp value)
    {
        task.Remove(value);
    }
}
