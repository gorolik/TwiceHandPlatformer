using Sources.Behaviour.Entities.CharacterParameters;
using UnityEngine;

namespace Sources.Behaviour.Equipments.Bonuses
{
    public abstract class Bonus : MonoBehaviour
    {
        public abstract void AddBonus(CharacterData characterData);
        public abstract void RemoveBonus(CharacterData characterData);
    }
}