using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TextFieldInspector : MonoBehaviour
{
    [TextArea]
    public string text;

    public GameObject owo, wow;

    private async void Start()
    {
        await Task.Delay(100);
        owo.SetActive(true);
        wow.SetActive(true);
    }
}
