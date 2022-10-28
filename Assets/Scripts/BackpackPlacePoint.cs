using System;
using System.Collections;
using System.Collections.Generic;
using Autohand;
using UnityEngine;

public class BackpackPlacePoint : PlacePoint
{
    public Vector3 defaulf;

    public Grabbable currentGrabbable;

    public override void Place(Grabbable placeObj)
    {
        base.Place(placeObj);
        placeObj.transform.parent = transform;
        currentGrabbable = placeObj;
    }

    public override void Remove(Grabbable placeObj)
    {
        base.Remove(placeObj);
        placeObj.transform.parent = null;
        currentGrabbable = null;
    }

    public void OpenBackpack()
    {
        transform.localScale = defaulf;
        if(currentGrabbable) currentGrabbable.isGrabbable = true;
    }

    public void CloseBackpack()
    {
        transform.localScale = new Vector3(0, 0, 0);
        if(currentGrabbable) currentGrabbable.isGrabbable = false;
    }
}
