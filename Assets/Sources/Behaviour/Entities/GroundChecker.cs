using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class GroundChecker : MonoBehaviour
    {
        private const float _groundCheckHeight = 0.1f;
        
        [SerializeField] private Collider2D _collider;
        [SerializeField] private LayerMask _groundMask;
        
        public bool IsGrounded()
        {
            var bounds = _collider.bounds;
            
            Vector2 boxCenter = bounds.center;
            Vector2 boxSize = bounds.size;
            
            return Physics2D.BoxCast(boxCenter, boxSize, 0, Vector2.down, _groundCheckHeight, _groundMask);
        }
    }
}