using System;
using UnityEngine;

namespace Sources.Behaviour.Entities.HealthSystem
{
    public class Hitbox : MonoBehaviour
    {
        [SerializeField] private Collider2D _collider;
        
        private Health _selfHealth;

        public event Action<Hurtbox> Hit; 
        
        public void SetSelfHealth(Health health) => 
            _selfHealth = health;

        public void SetColliderEnabled(bool value) =>
            _collider.enabled = value;
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out Hurtbox hurtbox) && hurtbox.Health != _selfHealth)
                Hit?.Invoke(hurtbox);
        }
    }
}