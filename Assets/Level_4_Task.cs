using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Event;
using Project;
using UnityEngine;
using UnityEngine.Events;

public class Level_4_Task : MonoBehaviour
{
    [SerializeField] private List<Lamp> taskGroup = new List<Lamp>();

    [SerializeField] private UnityEvent OnLevelPass;

    void Start()
    {
        EventBus.Subscribe<PlayerLightTheFireDetected>(OnPlayerLightTheFireDetected);
    }

    private void OnPlayerLightTheFireDetected(PlayerLightTheFireDetected obj)
    {
        var isLight = obj.isLight;
        var task = obj.lamp;

        if (isLight)
        {
            taskGroup.Add(task);
        }
        else
        {
            taskGroup.Remove(task);
        }

        if (taskGroup.Count == 3 && taskGroup.All(_ => _.correctAnswer == true))
        {
            OnLevelPass?.Invoke();
        }
    }
    
}
