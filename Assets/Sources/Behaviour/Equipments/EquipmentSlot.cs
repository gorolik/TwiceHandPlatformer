using Sources.Behaviour.Entities.CharacterParameters;
using UnityEngine;

namespace Sources.Behaviour.Equipments
{
    public abstract class EquipmentSlot : MonoBehaviour
    {
        [SerializeField] private Transform _generalParent;
        [SerializeField] private CharacterData _characterData;

        private Equipment _equipment;

        public virtual void Equip(Equipment equipment)
        {
            if (_equipment != null)
                UnEquip();

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
}