using Sources.Behaviour.Entities;
using UnityEngine;

namespace Sources.Behaviour.Items
{
    public abstract class Item : MonoBehaviour
    {
        [Header("Item")]
        [SerializeField] private Rigidbody2D _rigidbody;
        
        private bool _taken;

        public bool Taken => _taken;

        public abstract void UseBegin();
        public abstract void UseEnd();

        public void Take(Transform parent, CharacterHand hand)
        {
            _rigidbody.simulated = false;
            _rigidbody.isKinematic = true;

            transform.parent = parent;
            transform.localPosition = Vector2.zero;
            
            _taken = true;

            OnTaken(hand);
        }

        public void Drop()
        {
            _rigidbody.simulated = true;
            _rigidbody.isKinematic = false;
            
            transform.parent = null;

            _taken = false;

            OnDroped();
        }

        protected virtual void OnTaken(CharacterHand hand) { }

        protected virtual void OnDroped() { }
    }
}