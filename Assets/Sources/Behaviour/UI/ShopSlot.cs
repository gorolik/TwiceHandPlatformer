using UnityEngine;

namespace Sources.Behaviour.UI
{
    public class ShopSlot : ItemSlot
    {
        protected override void OnAction(ItemSlot slot)
        {
            if (slot is InventorySlot inventorySlot)
            {
                inventorySlot.SetItem(Item);
                inventorySlot.AttachItem(Item);
                Debug.Log("Купили");
                SetItem(null);
            }
        }

        protected override void OnDefinition()
        {
            if(Item != null)
                _slotType = Item.SlotType;
        }
    }
}