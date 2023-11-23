using Sources.Behaviour.Entities;
using UnityEngine;

namespace Sources.Behaviour.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private CharacterViewDirection _characterViewDirection;
        private bool _taken;

        public bool Taken => _taken;

        public abstract void UseBegin();
        public abstract void UseEnd();

        public void Take(Transform parent, CharacterViewDirection characterViewDirection, CharacterHand hand)
        {
            _characterViewDirection = characterViewDirection;
            
            _rigidbody.simulated = false;
            _rigidbody.isKinematic = true;

            transform.parent = parent;
            transform.localPosition = Vector2.zero;
            
            SyncDirection(_characterViewDirection.LookDirection);
            _characterViewDirection.DirectionChanged += SyncDirection;
            
            _taken = true;

            OnTaken(hand);
        }

        public void Drop()
        {
            _characterViewDirection.DirectionChanged -= SyncDirection;
            _characterViewDirection = null;
            
            _rigidbody.simulated = true;
            _rigidbody.isKinematic = false;
            
            transform.parent = null;

            _taken = false;
        }

        protected virtual void OnTaken(CharacterHand hand) { }

        private void OnDestroy()
        {
            if(_characterViewDirection != null)
                _characterViewDirection.DirectionChanged -= SyncDirection;
        }

        private void SyncDirection(CharacterViewDirection.Direction direction)
        {
            if (direction == CharacterViewDirection.Direction.Right) 
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(-1, -1);
        }
    }
}