using System;
using UnityEngine;

namespace Sources.Behaviour.Entities.CharacterParameters
{
    [Serializable]
    public class FloatGameParameter
    {
        [SerializeField] private float _defaultValue;
        [SerializeField] private float _minValue = 0;
        [SerializeField] private float _maxValue = 100;
        
        private float _bonus;

        public event Action<float> Changed; 

        public float CurrentValue => Mathf.Clamp(_defaultValue + _bonus, _minValue, _maxValue);

        public void Init() => 
            OnValueChanged();

        public void AddBonus(float value)
        {
            _bonus += value;
            Changed?.Invoke(CurrentValue);
        }
        
        protected virtual void OnValueChanged() { }
    }
}