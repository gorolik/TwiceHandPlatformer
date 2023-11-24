using System;
using Sources.Behaviour.Entities;
using UnityEngine;

namespace Sources.Behaviour
{
    public class Hitbox : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;

        public event Action<Hurtbox> Hit; 
        
        public void SetColliderEnabled(bool value) =>
            _collider.enabled = value;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Hurtbox hurtbox))
                Hit?.Invoke(hurtbox);
        }
    }
}