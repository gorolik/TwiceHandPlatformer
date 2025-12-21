using System;
using Sources.Behaviour.Entities.Player;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Behaviour.UI
{
    public class CrossLevelMenu : MonoBehaviour
    {
        [SerializeField] private InventoryDisplay _inventoryDisplay;
        [SerializeField] private Shop _shop;
        [SerializeField] private Button _closeButton;

        public event Action Closed;
        
        private void OnEnable() => 
            _closeButton.onClick.AddListener(OnCloseButtonClicked);

        private void OnDisable() => 
            _closeButton.onClick.RemoveListener(OnCloseButtonClicked);

        public void Open(PlayerRoot playerRoot)
        {
            gameObject.SetActive(true);
            _inventoryDisplay.Display(playerRoot);
            _shop.Init(playerRoot);
        }

        private void OnCloseButtonClicked()
        {
            gameObject.SetActive(false);
            Closed?.Invoke();
        }
    }
}