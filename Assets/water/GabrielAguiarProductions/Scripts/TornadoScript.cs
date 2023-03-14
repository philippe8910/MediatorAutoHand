using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class TornadoScript : MonoBehaviour
{

    public iTween.EaseType movementEaseType = iTween.EaseType.easeInOutSine;
    public float movementRadius = 30;
    public float movementSpeed = 0.5f;

    private Vector3 originalPosition;

    #region Pull Settings
    public Transform pullingCenter;
    public AnimationCurve pullingCenterCurve = AnimationCurve.Linear(0,1,1,1);
    public float pullRadius = 25;
    public float pullForce = 5000;
    public AnimationCurve pullForceCurve = AnimationCurve.EaseInOut(0,-1,1,1);

    private WaitForSeconds refreshRate = new WaitForSeconds(0.1f);
    private SphereCollider sCollider;
    #endregion
    

    void Start()
    {
        #region Pull Related
        sCollider = GetComponent<SphereCollider>();
        if (sCollider != null)
        {
            sCollider.isTrigger = true;
            sCollider.radius = pullRadius;
        }
        else
            Debug.Log("Add a SphereCollider");

        if (pullingCenter != null)
        {
            ChangeKeys(pullingCenterCurve, pullingCenter.position.y);
        }
        else
        {
            Debug.Log("Add an Empty GameObject as a PullingCenter");
            pullingCenter = transform;
            ChangeKeys(pullingCenterCurve, pullingCenter.position.y);
        }

        ChangeKeys(pullForceCurve, pullForce);
        #endregion

        originalPosition = transform.position;
        StartCoroutine(Movement());
    }

    void OnTriggerEnter (Collider co)
    {
        if(co.tag == "Bullet")
            StartCoroutine(IncreasePull(co, true));
    }

    void OnTriggerExit (Collider co)
    {
        if (co.tag == "Bullet")
            StartCoroutine(IncreasePull(co, false));
    }

    IEnumerator Movement()
    {
        //choose location
        var newPos = new Vector3 (originalPosition.x + Random.Range(-movementRadius,movementRadius), originalPosition.y, originalPosition.z + Random.Range(-movementRadius, movementRadius));
        var distance = newPos - originalPosition;
        var time = distance.magnitude / movementSpeed;

        //move to location        
        iTween.MoveTo(gameObject, iTween.Hash("position", newPos, "easeType", movementEaseType, "time", time));
        yield return new WaitForSeconds(time + 0.1f);
        StartCoroutine(Movement());
    }

    IEnumerator IncreasePull(Collider co, bool pull)
    {
        if (pull)
        {
            //pull force controlled by curve
            pullForce = pullForceCurve.Evaluate(((Time.time * 0.1f) % pullForceCurve.length));

            //get direction from tornado to object
            Vector3 forceDirection = pullingCenter.position - co.transform.position;

            //apply force to object towards tornado
            co.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * pullForce * Time.deltaTime);
            pullingCenter.position = new Vector3(pullingCenter.position.x, pullingCenterCurve.Evaluate(((Time.time * 0.1f) % pullingCenterCurve.length)), pullingCenter.position.z);
            yield return refreshRate;
            StartCoroutine(IncreasePull(co, pull));
        }
        else
        {
            //decrease pull force
            while (pullForce > 0)
            {
                if (pullForce - 250 < 0)
                    pullForce = 0;
                else
                    pullForce -= 250;

                yield return refreshRate;
            }
        }
    }
    public void ChangeKeys (AnimationCurve curve, float newValue)
    {
        Keyframe[] keys = curve.keys;

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].value *= newValue;
        }

        curve.keys = keys;
    }
}
