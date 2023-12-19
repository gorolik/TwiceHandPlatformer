using UnityEngine;

namespace Sources.Behaviour.Entities.HealthSystem
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] private Health _health;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public Health Health => _health;

        public void Push(float force, Vector2 direction)
        {
            if(_rigidbody != null)
                _rigidbody.AddForce(force * direction, ForceMode2D.Impulse);
        }
    }
}