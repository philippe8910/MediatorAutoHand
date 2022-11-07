using UnityEngine;

public class Level_1_Button : LevelEvents
{
    public Animator doorAnimator;

    private void Start()
    {
        //TryGetComponent<Animator>(out doorAnimator);
    }

    public override void OnTrigger()
    {
        base.OnTrigger();
        
        //doorAnimator.CrossFade("Open" , 0.1f);
        doorAnimator.Play("Open");
    }

    public override void OnRelease()
    {
        base.OnRelease();
        
        //doorAnimator.CrossFade("Close" , 0.1f);
        doorAnimator.Play("Close");
    }
}
