using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class Flies : Enemy
    {
        [SerializeField] private EnemyVision _vision;
        [SerializeField] private DirectToPlayerMover _mover;
        [SerializeField] private float _minDistance = 5;
        [SerializeField] private Health _health;

        private bool _inAttack;

        private void Update()
        {
            if(!Inited)
                return;

            float distanceToPlayer = Vector2.Distance(Player.ObservePoint.position, transform.position);

            bool seePlayer = _vision.SeePlayer(Player, _health);
            
            if(seePlayer)
                _mover.Rotate(Player.ObservePoint.position);

            if (seePlayer && distanceToPlayer > _minDistance && !_inAttack)
                _mover.Move(Player.ObservePoint.position);
            else if(seePlayer && !_inAttack)
            {
                _inAttack = true;
                Invoke(nameof(AttackEnd), 1.2f);
                
                Debug.Log("В атаке");
            }
        }

        private void AttackEnd()
        {
            _inAttack = false;
        }
    }
}