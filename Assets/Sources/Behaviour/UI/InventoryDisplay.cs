using System;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.UI
{
    public class InventoryDisplay : MonoBehaviour
    {
        [SerializeField] private InventorySlot[] _inventorySlots;

        public void Display(PlayerRoot playerRoot)
        {
            PlayerInventory inventory = playerRoot.Inventory;

            foreach (InventorySlot inventorySlot in _inventorySlots) 
                inventorySlot.Init(inventory);
        }
    }
}