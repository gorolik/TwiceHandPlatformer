using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterMove : MonoBehaviour
    {
        private const float _groundCheckHeight = 0.1f;

        [SerializeField] private float _moveSpeed = 8;
        [SerializeField] private float _jumpForce = 13;
        [SerializeField] private LayerMask _groundMask;
        [SerializeField] private Collider2D _collider;
        [SerializeField] private Rigidbody2D _rigidbody;
        
        public void Move(float horizontal)
        {
            Vector2 direction = new Vector2(horizontal, 0);
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
        }

        public void Jump()
        {
            if(IsGrounded())
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
        }

        private bool IsGrounded()
        {
            var bounds = _collider.bounds;
            
            Vector2 boxCenter = bounds.center;
            Vector2 boxSize = bounds.size;
            
            return Physics2D.BoxCast(boxCenter, boxSize, 0, Vector2.down, _groundCheckHeight, _groundMask);
        }
    }
}