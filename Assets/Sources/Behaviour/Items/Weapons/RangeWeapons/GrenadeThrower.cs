using Sources.Behaviour.Projectiles;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.RangeWeapons
{
    public class GrenadeThrower : RangeWeapon
    {
        [SerializeField] private float _damage = 5;
        [SerializeField] private float _throwPower = 50;
        [SerializeField] private Grenade _grenadePrefab;

        protected override void Shot()
        {
            Grenade grenade = Instantiate(_grenadePrefab, transform.position, transform.rotation * ProjectileUpEulerOffset);
            grenade.Init(_damage);
            
            grenade.Rigidbody.AddForce(grenade.transform.TransformDirection(Vector2.up) * _throwPower, ForceMode2D.Impulse);
        }
    }
}