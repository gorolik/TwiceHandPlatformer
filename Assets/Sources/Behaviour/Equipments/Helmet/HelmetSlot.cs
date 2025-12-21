using UnityEngine;

namespace Sources.Behaviour.Equipments.Helmet
{
    public class HelmetSlot : EquipmentSlot
    {
        [SerializeField] private Transform _head;

        protected override void Equip(Equipment equipment)
        {
            if(equipment is HelmetEquipment == false)
                return;
            
            base.Equip(equipment);
        }

        protected override void VisualEquip(Equipment equipment) { }
    }
}