using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class DirectToPlayerMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed = 10;
        [SerializeField] private float _rotationOffset;
        [SerializeField] private CharacterViewDirection _viewDirection;
        
        public void Move(Vector2 target) => 
            transform.Translate((target - (Vector2)transform.position).normalized * (_speed * Time.deltaTime), Space.World);

        public void Rotate(Vector2 to)
        {
            Vector2 directionToTarget = to - (Vector2)transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(Vector3.forward, directionToTarget);
            Quaternion validatedRotation = Quaternion.Euler(0, 0, _rotationOffset) * rotationToTarget;
            transform.rotation = Quaternion.Slerp(transform.rotation, validatedRotation, _rotationSpeed * Time.deltaTime);
            
            _viewDirection.SetCharacterViewToLookDirection(to.x, false, true);
        }
    }
}