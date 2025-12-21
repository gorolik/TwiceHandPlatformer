using System;
using System.Collections.Generic;
using Sources.Behaviour.Entities.Player;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Sources.Behaviour.UI
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image _icon;
        [SerializeField] private Sprite _emptyIcon;
        [SerializeField] private GameObject _infoPanel;
        [SerializeField] private Transform _draggableParent;
        [SerializeField] private Draggable _draggablePrefab;
        [SerializeField] protected SlotType _slotType;

        private PlayerRoot _player;
        private bool _dragging;
        private Draggable _draggableInstance;
        
        public SlotType SlotType => _slotType;

        protected DescribedThink Item;

        public void Init(PlayerRoot player) =>
            _player = player;

        private void Update()
        {
            if (_dragging && Input.GetMouseButtonUp(0))
                EndDragging();
        }

        public void SetItem(DescribedThink item)
        {
            Item = item;

            if (item == null)
            {
                _icon.sprite = _emptyIcon;
                return;
            }

            _icon.sprite = item.Icon;
            
            OnDefinition();
        }

        public void StartDragging()
        {
            if (Item == null)
                return;

            _dragging = true;

            _icon.sprite = _emptyIcon;
            _draggableInstance = Instantiate(_draggablePrefab, _draggableParent, true);
            _draggableInstance.Init(_icon.sprite);
        }

        protected virtual void OnAction(ItemSlot slot) { }
        protected virtual void OnDefinition() { }

        private void EndDragging()
        {
            _dragging = false;

            _icon.sprite = Item.Icon;
            Destroy(_draggableInstance.gameObject);

            if (TryGetSlot(out ItemSlot slot))
                if (slot.SlotType == Item.SlotType)
                    OnAction(slot);
        }

        private bool TryGetSlot(out ItemSlot slot)
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            if (raycastResults.Count > 0)
                foreach (var go in raycastResults)
                    if (go.gameObject.TryGetComponent(out slot))
                        return true;

            slot = null;
            return false;
        }

        public void ShowInfo()
        {
            if (Item == null)
                return;

            // логика показа информации

            _infoPanel.SetActive(true);
        }

        public void HideInfo() =>
            _infoPanel.SetActive(false);
    }
}