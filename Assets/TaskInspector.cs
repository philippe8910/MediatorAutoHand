using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Interface;
using UnityEngine;
using UnityEngine.Events;

public class TaskInspector : MonoBehaviour
{
    private List<ITask> taskList = new List<ITask>();

    private UnityEvent OnFinishAllTask;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    

    public void UpdateTaskCheck()
    {
        var taskComplete = taskList.Where(task => task.taskComplete != false);

        var allComplete = taskComplete.Count() == taskList.Count();

        if (allComplete)
        {
            OnFinishAllTask?.Invoke();
        }
    }
}
