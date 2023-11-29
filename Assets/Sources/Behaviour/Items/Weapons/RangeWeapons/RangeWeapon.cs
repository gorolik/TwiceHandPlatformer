using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.RangeWeapons
{
    public class RangeWeapon : Item
    {
        [Header("Settings")] 
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _fireRate = 1;
        [SerializeField] private Transform _projectilePrefab;

        private bool _fire;
        private float _shotTimer;
        
        public override void UseBegin() => 
            _fire = true;

        public override void UseEnd() => 
            _fire = false;

        private void Update()
        {
            if (_shotTimer > 0)
                _shotTimer -= Time.deltaTime;
            else if(_fire) 
                Shot();
        }

        private void Shot()
        {
            Transform projectile = Instantiate(_projectilePrefab, transform.position, transform.rotation);
            Debug.Log("Shot");
            
            _shotTimer = GetDelay();
        }

        private float GetDelay() =>
            1 / _fireRate;
    }
}