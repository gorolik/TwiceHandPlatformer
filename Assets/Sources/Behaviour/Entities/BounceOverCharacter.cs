using Sources.Behaviour.Entities.CharacterParameters;
using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class BounceOverCharacter : MonoBehaviour
    {
        private const float _radius = 1f;

        [SerializeField] private LayerMask _checkMask;
        [SerializeField] private Transform _checkPoint;
        [SerializeField] private CharacterData _characterData;

        private RaycastHit2D[] _hits = new RaycastHit2D[1];

        public bool TryBounceOverCharacter()
        {
            if (Physics2D.CircleCastNonAlloc(_checkPoint.position, _radius, Vector2.down, _hits, 0, _checkMask) > 0)
            {
                if (_hits[0].collider.TryGetComponent(out Hurtbox hurtbox))
                {
                    hurtbox.Health.TakeDamage(_characterData.BounceDamage.CurrentValue);

                    return true;
                }
            }

            return false;
        }
    }
}