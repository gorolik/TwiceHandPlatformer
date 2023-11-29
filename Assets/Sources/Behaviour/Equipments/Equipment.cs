using Sources.Behaviour.Entities.CharacterParameters;
using UnityEngine;

namespace Sources.Behaviour.Equipments
{
    public abstract class Equipment : MonoBehaviour
    {
        [SerializeField] private float _weight;

        public void Equip(CharacterData characterData)
        {
            characterData.Weight.AddBonus(_weight);
            AddBonus(characterData);
        }

        public void UnEquip(CharacterData characterData)
        {
            characterData.Weight.AddBonus(-_weight);
            RemoveBonus(characterData);
            
            Destroy(gameObject);
        }
        
        protected abstract void AddBonus(CharacterData characterData);
        protected abstract void RemoveBonus(CharacterData characterData);
    }
}