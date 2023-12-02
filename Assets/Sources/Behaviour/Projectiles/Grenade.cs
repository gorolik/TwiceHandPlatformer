using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;

namespace Sources.Behaviour.Projectiles
{
    public class Grenade : Projectile
    {
        [SerializeField] private float _timeToExplosion = 2;
        [SerializeField] private float _explosionRadius = 5;
        [SerializeField] private Rigidbody2D _rigidbody;

        private float _explosionTimer;
        private float _damage;

        public Rigidbody2D Rigidbody => _rigidbody;

        public void Init(float damage)
        {
            _damage = damage;
            
            _explosionTimer = _timeToExplosion;
        }

        private void Update()
        {
            if (_explosionTimer > 0) 
                _explosionTimer -= Time.deltaTime;
            else
                Explode();
        }

        private void Explode()
        {
            Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, _explosionRadius);

            foreach (Collider2D hit in hits)
                if (hit.TryGetComponent(out Hurtbox hurtbox))
                    ApplyDamage(hurtbox);

            Destroy(gameObject);
        }

        private void ApplyDamage(Hurtbox hurtbox)
        {
            float distance = Vector2.Distance(hurtbox.transform.position, transform.position);
            float damage = GetDamage(distance);
            
            hurtbox.Health.TakeDamage(damage);
        }

        private float GetDamage(float distance)
        {
            float normalizedDistance = Mathf.Clamp01(distance / _explosionRadius);
            float damage = _damage * (1 - normalizedDistance);
            
            return damage;
        }
    }
}