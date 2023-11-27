using System;
using UnityEngine;

namespace Sources.Behaviour.Entities.CharacterParameters
{
    [Serializable]
    public class WeightParameter : FloatGameParameter
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        protected override void OnValueChanged() => 
            _rigidbody.mass = CurrentValue;
    }
}