using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Behaviour.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class Draggable : MonoBehaviour
    {
        [SerializeField] private Image _icon;

        private RectTransform _rect;
        
        public void Init(Sprite icon)
        {
            _rect = GetComponent<RectTransform>();
            
            _icon.sprite = icon;
        }

        private void Update() => 
            _rect.position = Input.mousePosition;
    }
}