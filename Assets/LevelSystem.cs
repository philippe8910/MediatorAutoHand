using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private AamonAction player;

    [SerializeField] private GameObject beginMenu;

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
        if (levelIndex == -1)
        {
            player.gameObject.SetActive(true);
            beginMenu.SetActive(false);
        }
        
        levelIndex++;
        levelIndex = Mathf.Clamp(levelIndex , 0 , levelLists.Count);
        
        levelLists.ForEach(level => level.SetActive(false));
        levelLists[levelIndex].SetActive(true);
        
        levelLists[levelIndex].TryGetComponent<LevelData>(out var levelData);
        player.transform.position = levelData.playerStartPos.position;
    }
}
