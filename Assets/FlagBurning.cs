using System.Collections;
using System.Collections.Generic;
using Project;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class FlagBurning : MonoBehaviour
{
    [SerializeField] private Material currentMaterial;

    private float currentHeight;

    public UnityEvent onLevelPassEvent;

    // Start is called before the first frame update
    void Start()
    {
        if(currentMaterial == null) 
            Debug.LogError("None Material!!!");

        currentMaterial.SetFloat("_CurrentHeight" , 0);
        currentHeight = currentMaterial.GetFloat("_CurrentHeight");
        
        onLevelPassEvent.AddListener(delegate
        {
            StartCoroutine(startBurn());
        
            IEnumerator startBurn()
            {
                if (currentHeight >= -4)
                {
                    currentHeight -= 0.025f;
                    currentMaterial.SetFloat("_CurrentHeight" , currentHeight);

                    yield return new WaitForSeconds(.01f);
                
                    StartCoroutine(startBurn());
                }
                else
                {
                    yield return null;
                }
            }
        });
    }

    [Button]
    public void Test()
    {
        onLevelPassEvent.Invoke();
    }
}
