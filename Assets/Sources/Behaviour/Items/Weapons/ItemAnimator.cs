using System.Collections.Generic;
using UnityEngine;

namespace Sources.Behaviour.Items.Weapons
{
    public abstract class ItemAnimator : MonoBehaviour
    {
        private const string _animationsFolder = "Animations/";
        
        [SerializeField] private AnimationController _animationType;

        protected Animator Animator;
        
        public void Init(Animator handAnimator)
        {
            Animator = handAnimator;
            Animator.runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>(_animationsFolder + AnimationPath.GetValueOrDefault(_animationType));
        }
        
        private enum AnimationController
        {
            Sword, Shield
        }

        private Dictionary<AnimationController, string> AnimationPath = new Dictionary<AnimationController, string> // временная замена сервиса подгрузки анимаций
        {
            [AnimationController.Sword] = "MeleeWeapons/SwordController",
            [AnimationController.Shield] = "Shields/ShieldController",
        };
    }
}