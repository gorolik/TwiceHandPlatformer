using Sources.Behaviour.Equipments;
using Sources.Behaviour.Equipments.Boots;
using Sources.Behaviour.Equipments.Chestplates;
using Sources.Behaviour.Equipments.Gloves;
using Sources.Behaviour.Equipments.Helmet;
using Sources.Behaviour.Items;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerInventory : MonoBehaviour
    {
        [Header("Start setup")]
        [SerializeField] private DescribedItem _startRightHandItem;
        [SerializeField] private DescribedItem _startLeftHandItem;

        [Space]
        [SerializeField] private DescribedEquipment _startHelmet;
        [SerializeField] private DescribedEquipment _startChestplate;
        [SerializeField] private DescribedEquipment _startGloves;
        [SerializeField] private DescribedEquipment _startBoots;

        [Header("Links")] 
        [SerializeField] private PlayerHands _hands;
        [SerializeField] private PlayerEquipment _equipment;
        [SerializeField] private Slot _helmetSlot;
        [SerializeField] private Slot _chestplateSlot;
        [SerializeField] private Slot _glovesSlot;
        [SerializeField] private Slot _bootsSlot;
        [SerializeField] private Slot _leftHandSlot;
        [SerializeField] private Slot _rightHandSlot;
        
        public DescribedItem RightHandItem { get; private set; }
        public DescribedItem LeftHandItem { get; private set; }

        public DescribedEquipment Helmet { get; private set; }
        public DescribedEquipment Chestplate { get; private set; }
        public DescribedEquipment Gloves { get; private set; }
        public DescribedEquipment Boots { get; private set; }

        public Slot HelmetSlot => _helmetSlot;
        public Slot ChestplateSlot => _chestplateSlot;
        public Slot GlovesSlot => _glovesSlot;
        public Slot BootsSlot => _bootsSlot;
        public Slot LeftHandSlot => _leftHandSlot;
        public Slot RightHandSlot => _rightHandSlot;

        public void Init()
        {
            if(_startRightHandItem != null)
                SetItem(_startRightHandItem, PlayerHandType.Right);
            if(_startLeftHandItem != null)
                SetItem(_startLeftHandItem, PlayerHandType.Left);

            if (_startHelmet != null)
                SetEquipment(_startHelmet);
            if (_startChestplate != null)
                SetEquipment(_startChestplate);
            if (_startGloves != null)
                SetEquipment(_startGloves);
            if (_startBoots != null)
                SetEquipment(_startBoots);
        }

        public void SetItem(DescribedItem item, PlayerHandType hand)
        {
            Item itemInstance = Instantiate(item.ItemPrefab);

            if (hand == PlayerHandType.Right)
            {
                RightHandItem = item;
                _hands.RightHand.TryTakeItem(itemInstance);
            }
            else
            {
                LeftHandItem = item;
                _hands.LeftHand.TryTakeItem(itemInstance);
            }
        }

        public void SetEquipment(DescribedEquipment equipment)
        {
            Equipment equipmentInstance = Instantiate(equipment.EquipmentPrefab);

            /*switch (equipmentInstance)
            {
                case HelmetEquipment instance:
                    Helmet = equipment;
                    _equipment.EquipHelmet(instance);
                    break;
                case ChestplateEquipment instance:
                    Chestplate = equipment;
                    _equipment.EquipChestplate(instance);
                    break;
                case GlovesEquipment instance:
                    Gloves = equipment;
                    _equipment.EquipGloves(instance);
                    break;
                case BootsEquipment instance:
                    Boots = equipment;
                    _equipment.EquipBoots(instance);
                    break;
            }*/
        }
    }
}