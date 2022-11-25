using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    [SerializeField] private AamonAction player;

    [SerializeField] private Transform steamPlayer;

    [SerializeField] private GameObject beginMenu;
    
    [SerializeField] private List<Transform> playerPosition = new List<Transform>();

    [SerializeField] private List<Transform> aamonPosition = new List<Transform>();

    [SerializeField] private int levelIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelIndex = -1;

        //EventBus.Post(new ChangeScenesDetected(ChangeLevel));
    }
    
    [Button]
    public void LevelChangeTest()
    {
        EventBus.Post(new ChangeScenesDetected(ChangeLevel));
    }

    public void ResetLevelTest()
    {
        EventBus.Post(new ChangeScenesDetected(ResetLevel));
    }
    
    public void ChangeLevel()
    {
        /*
        if (levelIndex == -1)
        {
            player.gameObject.SetActive(true);
            //levelGround.SetActive(true);
            beginMenu.SetActive(false);
        }
        
        levelIndex++;
        levelIndex = Mathf.Clamp(levelIndex , 0 , playerPosition.Count);

        steamPlayer.position = playerPosition[levelIndex].position;
        player.transform.position = aamonPosition[levelIndex].position;
        */
    }

    public void ResetLevel()
    {
        levelIndex = Mathf.Clamp(levelIndex , 0 , playerPosition.Count);

        steamPlayer.position = playerPosition[levelIndex].position;
        player.transform.position = aamonPosition[levelIndex].position;
    }
}
