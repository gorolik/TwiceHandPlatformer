using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterViewDirection : MonoBehaviour
    {
        [SerializeField] private Transform _characterView;
        
        public enum Direction { Right, Left }

        private Direction _direction;
        
        public Direction LookDirection => _direction;
        
        public void SetCharacterViewToLookDirection(float xLookPoint)
        {
            if (xLookPoint > transform.position.x && _direction != Direction.Right)
            {
                _characterView.localScale = new Vector2(1, _characterView.localScale.y);
                _direction = Direction.Right;
            }
            else if (xLookPoint < transform.position.x && _direction != Direction.Left)
            {
                _characterView.localScale = new Vector2(-1, _characterView.localScale.y);
                _direction = Direction.Left;
            }
        }
    }
}