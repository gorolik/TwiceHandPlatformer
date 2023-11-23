using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.MeleeWeapons
{
    public class MeleeWeaponAnimator : MonoBehaviour
    {
        public static readonly int StageHash = Animator.StringToHash("Stage");
        
        [SerializeField] private string _animatorName = "MeleeController";

        private Animator _animator;
        
        public void Init(Animator handAnimator)
        {
            _animator = handAnimator;
            _animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animations/MeleeWeapons/" + _animatorName); // временная замена сервиса подгрузки анимаций
        }

        public void SetStage(int value) =>
            _animator.SetInteger(StageHash, value);
    }
}