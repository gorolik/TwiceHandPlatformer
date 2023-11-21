using UnityEngine;

namespace Sources.Behaviour.Items
{
    public abstract class Item : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        private bool _taken;

        public bool Taken => _taken;

        public abstract void Use();

        public void Take(Transform parent)
        {
            _rigidbody.simulated = false;
            _rigidbody.isKinematic = true;

            transform.parent = parent;
            transform.localPosition = Vector2.zero;

            _taken = true;
            
            Debug.Log(gameObject.name + " taked");
        }

        public void Drop()
        {
            _rigidbody.simulated = true;
            _rigidbody.isKinematic = false;
            
            transform.parent = null;

            _taken = false;
            
            Debug.Log(gameObject.name + " droped");
        }
    }
}