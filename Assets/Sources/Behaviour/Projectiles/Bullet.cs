using UnityEngine;

namespace Sources.Behaviour.Projectiles
{
    public class Bullet : Projectile
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _speed = 10;
        
        private Vector2 _previousPosition;
        private bool _isCollided;

        private void Update()
        {
            if(_isCollided)
                return;
            
            Move();
            TryCollide();
        }

        private void TryCollide()
        {
            if (IsCollide(out RaycastHit2D hit))
            {
                transform.position = hit.point;

                _isCollided = true;
                Destroy(gameObject);
            }
        }

        private void Move()
        {
            _previousPosition = transform.position;
            transform.Translate(transform.TransformDirection(Vector2.up) * (_speed * Time.deltaTime), Space.World);
        }

        private bool IsCollide(out RaycastHit2D hit)
        {
            Vector2 direction = _previousPosition - (Vector2)transform.position;
            float distance = Vector2.Distance(transform.position, _previousPosition);
            
            hit = Physics2D.Raycast(transform.position, direction, distance, _layerMask);
            
            return hit.collider != null;
        }
    }
}