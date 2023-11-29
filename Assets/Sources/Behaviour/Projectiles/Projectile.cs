using UnityEngine;

namespace Sources.Behaviour.Projectiles
{
    public abstract class Projectile : MonoBehaviour
    {
        private float _damage;
        
        public void Init(float damage)
        {
            _damage = damage;
        }
    }
}