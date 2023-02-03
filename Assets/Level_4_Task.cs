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

    [SerializeField] private List<GameObject> candleFire = new List<GameObject>();

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
            if (!taskGroup.Contains(task))
            {
                taskGroup.Add(task);   
            }
        }
        else
        {
            taskGroup.Remove(task);
        }

        if (taskGroup.Count == 4)
        {
            if (taskGroup[0].correctAnswerIndex == 0 && taskGroup[1].correctAnswerIndex == 1 && taskGroup[2].correctAnswerIndex == 2 && taskGroup[3].correctAnswerIndex == 3)
            {
                OnLevelPass?.Invoke();
            }
        }
        
        candleFire.ForEach(delegate(GameObject o)
        {
            o.SetActive(true);
        });
        
        if (taskGroup[0]?.correctAnswerIndex == 0)
        {
            candleFire[0].SetActive(false);
            
            if (taskGroup[1]?.correctAnswerIndex == 1)
            {
                candleFire[1].SetActive(false);
                
                if (taskGroup[2]?.correctAnswerIndex == 2)
                {
                    candleFire[2].SetActive(false);
                    
                    if (taskGroup[3]?.correctAnswerIndex == 3)
                    {
                        candleFire[3].SetActive(false);
                    }
                }
            }
        }

        /*
         * 
         */
    }
    
}
