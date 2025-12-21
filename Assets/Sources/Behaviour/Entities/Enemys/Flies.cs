using System;
using Sources.Behaviour.Entities.HealthSystem;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class Flies : Enemy
    {
        [SerializeField] private EnemyVision _vision;
        [SerializeField] private DirectToPlayerMover _mover;
        [SerializeField] private Hitbox _hitBox;
        [SerializeField] private float _damage = 20;
        [SerializeField] private float _minDistance = 5;
        [SerializeField] private float _jerkSpeed = 40;
        [SerializeField] private float _successJerkDistance = 0.2f;
        [SerializeField] private float _jerkCooldown;

        public enum State { Peace, Attack, Cooldown }

        private State _state;

        private float _cooldownTimer;

        public override void Init(PlayerRoot player)
        {
            base.Init(player);
            
            _hitBox.SetSelfHealth(Health);
            _hitBox.Hit += OnHit;
        }

        private void OnDestroy() => 
            _hitBox.Hit -= OnHit;

        private void OnHit(Hurtbox hurtbox) => 
            hurtbox.Health.TakeDamage(_damage);

        private void Update()
        {
            if(!Inited)
                return;

            Vector2 playerTargetPoint = Player.ObservePoint.position;
            float distanceToPlayer = Vector2.Distance(playerTargetPoint, transform.position);
            bool seePlayer = _vision.SeePlayer(Player, Health);

            if(seePlayer)
                _mover.Rotate(playerTargetPoint);

            if (_state == State.Cooldown)
            {
                _cooldownTimer -= Time.deltaTime;

                if (_cooldownTimer <= 0)
                    _state = State.Peace; 
                
                return;
            }

            if (seePlayer && distanceToPlayer > _minDistance && _state != State.Attack)
                _mover.Move(playerTargetPoint);
            else if (seePlayer && _state != State.Attack)
            {
                _state = State.Attack;
                _hitBox.SetColliderEnabled(true);
            }

            if (_state == State.Attack)
            {
                transform.position =
                    Vector3.MoveTowards(transform.position, playerTargetPoint, _jerkSpeed * Time.deltaTime);

                if (Vector2.Distance(playerTargetPoint, transform.position) <= _successJerkDistance)
                {
                    _hitBox.SetColliderEnabled(false);
                    _cooldownTimer = _jerkCooldown;
                    _state = State.Cooldown;
                }
            }
        }
    }
}