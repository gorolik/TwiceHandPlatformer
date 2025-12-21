using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public abstract class DescribedThink : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _icon;
        [SerializeField] private SlotType _slotType;

        public string Name => _name;
        public string Description => _description;
        public Sprite Icon => _icon;
        public SlotType SlotType => _slotType;
    }
}