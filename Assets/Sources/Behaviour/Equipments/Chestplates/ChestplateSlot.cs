using UnityEngine;

namespace Sources.Behaviour.Equipments.Chestplates
{
    public class ChestplateSlot : EquipmentSlot
    {
        [SerializeField] private Transform _body;

        public override void Equip(Equipment equipment)
        {
            if(equipment is ChestplateEquipment == false)
                return;
            
            base.Equip(equipment);
        }

        protected override void VisualEquip(Equipment equipment) { }
    }
}