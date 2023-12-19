using System;
using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterViewDirection : MonoBehaviour
    {
        [SerializeField] private Transform _characterView;
        
        public enum Direction { Right, Left }

        private Direction _direction;
        
        public Direction LookDirection => _direction;

        public event Action<Direction> DirectionChanged;

        public void SetCharacterViewToLookDirection(float xLookPoint, bool invertX = true, bool invertY = false)
        {
            Direction newDirection = xLookPoint > transform.position.x ? Direction.Right : Direction.Left;

            if (_direction != newDirection)
            {
                Vector3 currentScale = _characterView.localScale;
                
                float scaleX = invertX ? -currentScale.x : currentScale.x;
                float scaleY = invertY ? -currentScale.y : currentScale.y;

                _characterView.localScale = new Vector2(scaleX, scaleY);
                _direction = newDirection;
                DirectionChanged?.Invoke(_direction);
            }
        }
    }
}