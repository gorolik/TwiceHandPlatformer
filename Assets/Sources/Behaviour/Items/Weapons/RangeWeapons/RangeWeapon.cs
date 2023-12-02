using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.RangeWeapons
{
    public abstract class RangeWeapon : Item
    {
        protected static Quaternion ProjectileUpEulerOffset => Quaternion.Euler(0, 0, -90);
        
        [SerializeField] private float _fireRate = 1;

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
            else if (_fire)
            {
                Shot();
                _shotTimer = GetDelay();
            }
        }

        protected abstract void Shot();

        private float GetDelay() =>
            1 / _fireRate;
    }
}