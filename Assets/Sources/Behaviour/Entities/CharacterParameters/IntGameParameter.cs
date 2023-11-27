using System;
using UnityEngine;

namespace Sources.Behaviour.Entities.CharacterParameters
{
    [Serializable]
    public class IntGameParameter
    {
        [SerializeField] private int _defaultValue;
        [SerializeField] private int _minValue = 0;
        [SerializeField] private int _maxValue = 100;
        
        private int _bonus;

        public event Action<int> Changed; 

        public int CurrentValue => Mathf.Clamp(_defaultValue + _bonus, _minValue, _maxValue);

        public void Init() => 
            OnValueChanged();

        public void AddBonus(int value)
        {
            _bonus += value;
            Changed?.Invoke(CurrentValue);
        }
        
        protected virtual void OnValueChanged() { }
    }
}