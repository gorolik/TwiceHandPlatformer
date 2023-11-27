using UnityEngine;

namespace Sources.Behaviour.Entities.HealthSystem
{
    public class Health : MonoBehaviour
    {
        [Header("Values")]
        [SerializeField] private float _value = 100;
        [SerializeField] private float _maxValue = 100;
        [Header("Links")] 
        [SerializeField] private GameObject _rootObject;

        private bool _death;
        
        public float Value
        {
            get => _value;
            private set => _value = Mathf.Clamp(value, 0, _maxValue);
        }

        private void OnValidate() => 
            _value = Mathf.Clamp(_value, 0, _maxValue);

        public void TakeDamage(float damage)
        {
            if(_death)
                return;
            
            damage = Mathf.Clamp(damage, 0, float.MaxValue);

            Value -= damage;
            
            Debug.Log($"Health: {Value}, Damage: {damage}");
            TryDeath();
        }

        private void TryDeath()
        {
            if (Value <= 0 && !_death)
            {
                _death = true;
                Destroy(_rootObject);

                Debug.Log("Смерть");
            }
        }
    }
}