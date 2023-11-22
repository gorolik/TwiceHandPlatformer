using System;
using UnityEngine;

namespace Sources.Services.Input
{
    public class InputService : IInputService
    {
        private const string _horizontalAxis = "Horizontal";
        private const string _jumpButton = "Jump";
        private const string _leftMouseButton = "Fire1";
        private const string _rightMouseButton = "Fire2";
        private const string _abilityButton = "Ability";
        
        public float HorizontalAxis { get; private set; }
        public Vector2 MousePosition { get; private set; }
        public event Action JumpStart;
        public event Action JumpEnd;
        public event Action LeftFire;
        public event Action RightFire;
        public event Action Ability;
        
        public void Update()
        {
            UpdateHorizontalAxis();
            UpdateMousePosition();
            TryStartJump();
            TryEndJump();
            TryLeftFire();
            TryRightFire();
            TryAbility();
        }

        private void UpdateHorizontalAxis() => 
            HorizontalAxis = UnityEngine.Input.GetAxis(_horizontalAxis);

        private void UpdateMousePosition() => 
            MousePosition = UnityEngine.Input.mousePosition;

        private void TryStartJump()
        {
            if (UnityEngine.Input.GetButtonDown(_jumpButton))
                JumpStart?.Invoke();
        }
        
        private void TryEndJump()
        {
            if (UnityEngine.Input.GetButtonUp(_jumpButton))
                JumpEnd?.Invoke();
        }

        private void TryLeftFire()
        {
            if(UnityEngine.Input.GetButton(_leftMouseButton))
                LeftFire?.Invoke();
        }

        private void TryRightFire()
        {
            if(UnityEngine.Input.GetButton(_rightMouseButton))
                RightFire?.Invoke();
        }

        private void TryAbility()
        {
            if(UnityEngine.Input.GetButton(_abilityButton))
                Ability?.Invoke();
        }
    }
}
