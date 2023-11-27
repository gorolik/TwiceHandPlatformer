using Sources.Behaviour.Entities;
using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.Shields
{
    public class Shield : Item
    {
        [Header("Settings")]
        [SerializeField] private float _pushForce = 10;
        [SerializeField] private float _decisionTime = 0.2f;
        [SerializeField] private float _pushCooldown = 0.2f;

        [Header("Links")]
        [SerializeField] private Hitbox _hitbox;
        [SerializeField] private ShieldAnimator _animator;
        
        private ImpactEventHandler _eventHandler;
        
        private float _decisionTimer;
        private float _pushCooldownTimer;

        protected override void OnTaken(CharacterHand hand)
        {
            _animator.Init(hand.Animator);

            _eventHandler = hand.EventHandler;
            
            _eventHandler.ImpactStateChanged += AttackStateChanged;
            _hitbox.Hit += OnHit;
        }

        protected override void OnDroped()
        {
            _eventHandler.ImpactStateChanged -= AttackStateChanged;
            _hitbox.Hit -= OnHit;
        }

        private void Update()
        {
            UpdatePushCooldownTimer();
            UpdateDecisionTimer();
        }

        public override void UseBegin() => 
            _decisionTimer = _decisionTime;

        public override void UseEnd()
        {
            if (_decisionTimer > 0 && _pushCooldownTimer <= 0)
                Push();
            else
                ToWait();
        }

        private void OnHit(Hurtbox hurtbox) => 
            hurtbox.Push(_pushForce, hurtbox.transform.position - transform.position);

        private void AttackStateChanged(bool value) => 
            _hitbox.SetColliderEnabled(value);

        private void ToProtect() => 
            _animator.Protection(true);

        private void Push()
        {
            _animator.Protection(false);
            _animator.Push();

            _decisionTimer = 0;
            _pushCooldownTimer = _pushCooldown;
        }

        private void ToWait() => 
            _animator.Protection(false);

        private void UpdatePushCooldownTimer()
        {
            if (_pushCooldownTimer > 0)
                _pushCooldownTimer -= Time.deltaTime;
        }

        private void UpdateDecisionTimer()
        {
            if (_decisionTimer > 0)
            {
                _decisionTimer -= Time.deltaTime;

                if (_decisionTimer <= 0)
                    ToProtect();
            }
        }
    }
}