using Sources.Behaviour.Entities;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.MeleeWeapons
{
    public class MeleeWeapon : Item
    {
        [SerializeField] private ComboData _comboData;

        [SerializeField] private MeleeWeaponAnimator _animator;
        
        private int _comboStage;
        private float _comboContinueTimer;
        private float _stageDelayTimer;
        
        protected override void OnTaken(CharacterHand hand) => 
            _animator.Init(hand.Animator);

        private void Update()
        {
            if (_comboContinueTimer > 0)
            {
                _comboContinueTimer -= Time.deltaTime;

                if (_comboContinueTimer <= 0)
                {
                    _comboContinueTimer = 0;
                    ResetCombo();
                }
            }

            if (_stageDelayTimer > 0)
            {
                _stageDelayTimer -= Time.deltaTime;

                if (_stageDelayTimer < 0)
                    _stageDelayTimer = 0;
            }
        }

        public override void UseBegin()
        {
            if(_stageDelayTimer > 0)
                return;
            
            if (ComboEnd()) 
                ResetCombo();
            else
            {
                ComboData.Stage stage = _comboData.Stages[_comboStage];

                HitScan();
                _animator.SetStage(_comboStage + 1);
                
                _stageDelayTimer = stage.ContinueDelay;
                _comboContinueTimer = stage.ContinueTime;
                
                _comboStage++;
            }
        }

        private void HitScan()
        {
            Debug.Log("HitScan");
        }

        public override void UseEnd() { }

        private bool ComboEnd() => 
            _comboStage >= _comboData.Stages.Length;

        private void ResetCombo()
        {
            _comboStage = 0;
            _stageDelayTimer = 0;
            _comboContinueTimer = 0;
            _animator.SetStage(0);
        }
    }
}