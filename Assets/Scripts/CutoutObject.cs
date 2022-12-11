using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutoutObject : MonoBehaviour
{
    private void Start()
    {
        
    }

    public int Plus(int a , int b)
    {
        
        return a + b;
    }
    
    public int SmallestEvenMultiple(int n)
    {
        int ans = 0;
        int take = 1;
        while (true)
        {
            if ((n * take) % 2 == 0)
            {
                break;
            }
            take++;
            ans = n * take;
            
        }
        return ans;
    }
}
