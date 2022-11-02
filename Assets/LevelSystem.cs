using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> levelLists = new List<GameObject>();

    [SerializeField] private int levelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelIndex = -1;
        
        EventBus.Post(new ChangeScenesDetected(ChangeLevel));
    }
    
    [Button]
    public void LevelChangeTest()
    {
        EventBus.Post(new ChangeScenesDetected(ChangeLevel));
    }
    
    public void ChangeLevel()
    {
        levelIndex++;
        levelIndex = Mathf.Clamp(levelIndex , 0 , levelLists.Count);
        
        levelLists.ForEach(level => level.SetActive(false));
        levelLists[levelIndex].SetActive(true);
    }
}
