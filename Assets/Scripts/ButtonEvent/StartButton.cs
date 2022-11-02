using System.Collections;
using System.Collections.Generic;
using Event;
using Interface;
using Project;
using Sirenix.OdinInspector;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : ButtonEvent.ButtonEvent
{
    public override void OnClick()
    {
        EventBus.Post(new ChangeScenesDetected(OnChangeLevel));
    }

    [Button]
    public void StartTest()
    {
        OnClick();
    }

    private void OnChangeLevel()
    {
        transform.parent.gameObject.SetActive(false);
        Debug.Log("Start Game");
    }
}
