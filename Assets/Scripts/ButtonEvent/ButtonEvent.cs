using System;
using UnityEngine;
using UnityEngine.UI;

namespace ButtonEvent
{
    public class ButtonEvent : MonoBehaviour
    {
        private void Start()
        {
            TryGetComponent<Button>(out var button);
            
            button.onClick.AddListener(OnClick);
        }

        public virtual void OnClick()
        {
            
        }
    }
}