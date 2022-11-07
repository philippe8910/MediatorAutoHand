using Event;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;

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
