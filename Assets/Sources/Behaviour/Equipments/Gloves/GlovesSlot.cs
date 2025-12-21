using UnityEngine;

namespace Sources.Behaviour.Equipments.Gloves
{
    public class GlovesSlot : EquipmentSlot
    {
        [SerializeField] private Transform _rightHand;
        [SerializeField] private Transform _leftHand;

        protected override void Equip(Equipment equipment)
        {
            if(equipment is GlovesEquipment == false)
                return;
            
            base.Equip(equipment);
        }

        protected override void VisualEquip(Equipment equipment)
        {
            GlovesEquipment glovesEquipment = equipment as GlovesEquipment;

            ParentEquip(_rightHand, glovesEquipment.RightGlove);
            ParentEquip(_leftHand, glovesEquipment.LeftGlove);
        }
    }
}