using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class Hurtbox : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public void TakeDamage(float damage)
        {
            Debug.Log("Taked Damage: " + damage);
        }

        public void Push(float force, Vector2 direction)
        {
            _rigidbody.AddForce(force * direction, ForceMode2D.Impulse);
        }
    }
}