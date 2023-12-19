using Sources.Behaviour.Entities.CharacterParameters;
using Sources.Behaviour.Equipments.Bonuses;
using UnityEngine;

namespace Sources.Behaviour.Equipments
{
    public abstract class Equipment : MonoBehaviour
    {
        [SerializeField] private float _weight;

        private Bonus[] _bonuses;
        
        public void Init() => 
            _bonuses = GetComponents<Bonus>();

        public void Equip(CharacterData characterData)
        {
            characterData.Weight.AddBonus(_weight);
            
            foreach (Bonus bonus in _bonuses) 
                bonus.AddBonus(characterData);
        }

        public void UnEquip(CharacterData characterData)
        {
            characterData.Weight.AddBonus(-_weight);
            
            foreach (Bonus bonus in _bonuses) 
                bonus.RemoveBonus(characterData);
            
            Destroy(gameObject);
        }
    }
}