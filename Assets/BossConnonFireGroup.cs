using System.Collections;
using System.Collections.Generic;
using Event;
using Project;
using UnityEngine;

public class BossConnonFireGroup : MonoBehaviour
{
    public List<BossConnonAction> connonActions = new List<BossConnonAction>();

    public bool isStop;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnBossFireDetected(bool isStop)
    {
        StopAllCoroutines();
        StartCoroutine(StartFire());

        IEnumerator StartFire()
        {
            if (!isStop)
            {
                connonActions.ForEach(delegate(BossConnonAction action)
                {
                    action.Aim();
                });

                yield return new WaitForSeconds(1);
                
                for (int i = 0; i < connonActions.Count; i++)
                {
                    connonActions[i].Fire();
                    yield return new WaitForSeconds(0.35f);
                }
                
                yield return new WaitForSeconds(0.35f);
                StartCoroutine(StartFire());
            }
            else
            {
                connonActions.ForEach(delegate(BossConnonAction action)
                {
                    action.DisAim();
                });
                yield return null;
            }
        }
    }
    
    

}
