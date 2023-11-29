using Sources.Behaviour.Entities.CharacterParameters;
using UnityEngine;

namespace Sources.Behaviour.Equipments.Boots
{
    public class DragonBoots : BootsEquipment
    {
        [SerializeField] private int _jumpsCountBonus = 1;
        
        protected override void AddBonus(CharacterData characterData) => 
            characterData.JumpsCount.AddBonus(_jumpsCountBonus);

        protected override void RemoveBonus(CharacterData characterData) => 
            characterData.JumpsCount.AddBonus(-_jumpsCountBonus);
    }
}