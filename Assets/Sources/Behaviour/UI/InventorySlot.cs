using Sources.Behaviour.Entities.Player;
using Sources.Behaviour.Equipments;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Behaviour.UI
{
    public class InventorySlot : ItemSlot
    {
        [SerializeField] private InventorySlotType _inventorySlotType;
        
        private Slot _slot;

        public void Init(PlayerInventory playerInventory)
        {
            switch (_inventorySlotType)
            {
                case InventorySlotType.Helmet:
                    _slot = playerInventory.HelmetSlot;
                    break;
                case InventorySlotType.Chestplate:
                    _slot = playerInventory.ChestplateSlot;
                    break;
                case InventorySlotType.Gloves:
                    _slot = playerInventory.GlovesSlot;
                    break;
                case InventorySlotType.Boots:
                    _slot = playerInventory.BootsSlot;
                    break;
                case InventorySlotType.LeftHand:
                    _slot = playerInventory.LeftHandSlot;
                    break;
                case InventorySlotType.RightHand:
                    _slot = playerInventory.RightHandSlot;
                    break;
            }
            
            if(_slot != null)
                SetItem(_slot.DescribedThink);
        }

        public void AttachItem(DescribedThink item) => 
            _slot.Set(item);

        protected override void OnAction(ItemSlot slot)
        {
            if (slot is InventorySlot inventorySlot)
            {
                inventorySlot.SetItem(Item);
                inventorySlot.AttachItem(Item);
                SetItem(null);
            }
        }
        
        public enum InventorySlotType
        {
            Helmet,
            Chestplate,
            Gloves,
            Boots,
            LeftHand,
            RightHand
        }
    }
}