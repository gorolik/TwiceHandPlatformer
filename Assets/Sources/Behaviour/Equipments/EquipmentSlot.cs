using Sources.Behaviour.Entities.CharacterParameters;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Equipments
{
    public abstract class EquipmentSlot : Slot
    {
        [SerializeField] private Transform _generalParent;
        [SerializeField] private CharacterData _characterData;

        private Equipment _equipment;

        protected override bool TrySet(DescribedThink describedThink)
        {
            if (describedThink is DescribedEquipment)
            {
                Equip(describedThink as DescribedEquipment);
                return true;
            }

            return false;
        }

        private void Equip(DescribedEquipment equipment)
        {
            Equipment equipmentInstance = Instantiate(equipment.EquipmentPrefab);
            Equip(equipmentInstance);
        }

        protected virtual void Equip(Equipment equipment)
        {
            if (_equipment != null)
                UnEquip();

            equipment.Init();
            equipment.Equip(_characterData);
            _equipment = equipment;

            ParentEquip(_generalParent, equipment.transform);
            VisualEquip(equipment);
        }

        protected void ParentEquip(Transform parent, Transform equipmentPart)
        {
            equipmentPart.parent = parent;
            equipmentPart.localPosition = Vector2.zero;
            equipmentPart.localRotation = Quaternion.identity;
        }

        protected abstract void VisualEquip(Equipment equipment);

        private void UnEquip()
        {
            _equipment.UnEquip(_characterData);
            _equipment = null;
        }
    }

    public abstract class Slot : MonoBehaviour
    {
        private DescribedThink _describedThink;

        public DescribedThink DescribedThink => _describedThink;

        public void Set(DescribedThink describedThink)
        {
            if (TrySet(describedThink))
                _describedThink = describedThink;
        }

        protected abstract bool TrySet(DescribedThink describedThink);
    }
}