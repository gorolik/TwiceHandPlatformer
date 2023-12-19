using Sources.Behaviour.Entities.CharacterParameters;
using UnityEngine;

namespace Sources.Behaviour.Equipments.Bonuses
{
    public class JumpCountBonus : Bonus
    {
        [SerializeField] [Range(1, 2)] private int _baseBonus = 1;
        
        public override void AddBonus(CharacterData characterData) => 
            characterData.JumpsCount.AddBonus(_baseBonus);

        public override void RemoveBonus(CharacterData characterData) => 
            characterData.JumpsCount.AddBonus(-_baseBonus);
    }
}