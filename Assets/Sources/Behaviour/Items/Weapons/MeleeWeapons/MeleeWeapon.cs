using System.Collections.Generic;
using Sources.Behaviour.Entities;
using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.MeleeWeapons
{
    public class MeleeWeapon : Item
    {
        [Header("Settings")]
        [SerializeField] private float _damage = 10;
        [SerializeField] private ComboData _comboData;
        
        [Header("Links")]
        [SerializeField] private TrailRenderer _trail;

        [SerializeField] private Hitbox _hitbox;
        [SerializeField] private MeleeWeaponAnimator _animator;

        private ImpactEventHandler _eventHandler;
        private List<Health> _attacked = new List<Health>();

        private int _comboStage;
        private float _comboContinueTimer;
        private float _stageDelayTimer;

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
            UpdateComboContinueTimer();
            UpdateStageDelayTimer();
        }

        public override void UseBegin()
        {
            if(_stageDelayTimer > 0)
                return;
            
            if (ComboEnd()) 
                ResetCombo();
            else
                ContinueCombo();
        }

        public override void UseEnd() { }

        public void OnHit(Hurtbox hurtbox)
        {
            Health health = hurtbox.Health;
            
            if (!_attacked.Contains(health))
            {
                ComboData.Stage stage = _comboData.Stages[_comboStage];
                
                float damage = _damage * stage.DamageRatio;
                health.TakeDamage(damage);
                
                hurtbox.Push(stage.PushForce, hurtbox.transform.position - transform.position);
                
                _attacked.Add(health);
            }
        }

        private void ContinueCombo()
        {
            ComboData.Stage stage = _comboData.Stages[_comboStage];

            _animator.SetStage(_comboStage + 1);

            _stageDelayTimer = stage.ContinueDelay;
            _comboContinueTimer = stage.ContinueTime;
        }

        private void ResetCombo()
        {
            _comboStage = 0;
            _stageDelayTimer = 0;
            _comboContinueTimer = 0;
            _animator.SetStage(0);
        }

        private bool ComboEnd() => 
            _comboStage >= _comboData.Stages.Length;

        private void AttackStateChanged(bool isAttack)
        {
            _attacked.Clear();
            
            _hitbox.SetColliderEnabled(isAttack);
            _trail.emitting = isAttack;

            if (!isAttack)
                _comboStage++;
        }
        
        private void UpdateStageDelayTimer()
        {
            if (_stageDelayTimer > 0) 
                _stageDelayTimer -= Time.deltaTime;
        }

        private void UpdateComboContinueTimer()
        {
            if (_comboContinueTimer > 0)
            {
                _comboContinueTimer -= Time.deltaTime;

                if (_comboContinueTimer <= 0) 
                    ResetCombo();
            }
        }
    }
}