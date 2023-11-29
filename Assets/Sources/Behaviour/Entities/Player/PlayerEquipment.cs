using Sources.Behaviour.Equipments;
using Sources.Behaviour.Equipments.Boots;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerEquipment : MonoBehaviour
    {
        [SerializeField] private BootsSlot _boots;
        [SerializeField] private BootsEquipment _startEquipmentPrefab;

        private void Start()
        {
            BootsEquipment equipment = Instantiate(_startEquipmentPrefab);
            EquipBoots(equipment);
        }

        public void TryEquip(Equipment equipment)
        {
            // место для визитёра
        }

        public void EquipBoots(BootsEquipment equipment)
        {
            _boots.Equip(equipment);
        }
    }
}