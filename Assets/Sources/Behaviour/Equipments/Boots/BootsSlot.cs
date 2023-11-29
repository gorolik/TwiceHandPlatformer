using UnityEngine;

namespace Sources.Behaviour.Equipments.Boots
{
    public class BootsSlot : EquipmentSlot
    {
        [SerializeField] private Transform _leftLeg;
        [SerializeField] private Transform _rightLeg;
        
        public override void Equip(Equipment equipment)
        {
            if(equipment is BootsEquipment == false)
                return;
            
            base.Equip(equipment);
        }

        protected override void VisualEquip(Equipment equipment)
        {
            BootsEquipment bootsEquipment = equipment as BootsEquipment;
            
            ParentEquip(_leftLeg, bootsEquipment.LeftBoot);
            ParentEquip(_rightLeg, bootsEquipment.RightBoot);
        }
    }
}