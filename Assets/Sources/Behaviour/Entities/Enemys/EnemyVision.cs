using Sources.Behaviour.Entities.HealthSystem;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class EnemyVision : MonoBehaviour
    {
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private Transform _observePoint;

        private RaycastHit2D[] _hits = new RaycastHit2D[3];
        
        public bool SeePlayer(PlayerRoot player, Health selfHeatlh)
        {
            Transform playerObservablePoint = player.ObservePoint;

            var observePoint = _observePoint.position;
            var observablePoint = playerObservablePoint.position;
            
            Vector2 direction = observablePoint - observePoint;
            float distance = Vector2.Distance(observablePoint, observePoint);

            Physics2D.RaycastNonAlloc(observePoint, direction, _hits, distance, _layerMask);

            foreach (RaycastHit2D hit in _hits)
            {
                if (hit.collider != null)
                    if (hit.collider.TryGetComponent(out Hurtbox hurtbox) && hurtbox.Health == player.Health)
                        return true;
                    else if(hurtbox == null || hurtbox.Health != selfHeatlh)
                        return false;
            }
            
            return false;
        }
    }
}