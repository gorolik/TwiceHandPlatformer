using Sources.Behaviour.Projectiles;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.RangeWeapons
{
    public class Gun : RangeWeapon
    {
        [SerializeField] private float _damage = 5;
        [SerializeField] private Bullet _bulletPrefab;
        
        protected override void Shot()
        {
            Bullet bullet = Instantiate(_bulletPrefab, transform.position, transform.rotation * ProjectileUpEulerOffset);
            bullet.Init(SelfHealth, _damage);
        }
    }
}