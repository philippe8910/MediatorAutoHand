using System.Collections;
using System.Collections.Generic;
using Autohand;
using Event;
using Project;
using UnityEngine;

public class GrabbableCustom : MonoBehaviour
{
    private Grabbable _grabbable;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent<Grabbable>(out _grabbable);
        
        _grabbable.OnHighlightEvent += delegate(Hand hand, Grabbable grabbable)
        {
            EventBus.Post(new PlayerSelectGrabbableObjectDetected(transform)); 
        };
        
        _grabbable.OnUnhighlightEvent += delegate(Hand hand, Grabbable grabbable)
        {
            EventBus.Post(new PlayerSelectGrabbableObjectDetected(null)); 
        };
    }
    
}
