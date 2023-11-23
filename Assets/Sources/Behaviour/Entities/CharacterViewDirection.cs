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

        public void SetCharacterViewToLookDirection(float xLookPoint)
        {
            Direction newDirection = xLookPoint > transform.position.x ? Direction.Right : Direction.Left;

            if (_direction != newDirection)
            {
                _characterView.localScale = new Vector2(newDirection == Direction.Right ? 1 : -1, _characterView.localScale.y);
                _direction = newDirection;
                DirectionChanged?.Invoke(_direction);
            }
        }
    }
}