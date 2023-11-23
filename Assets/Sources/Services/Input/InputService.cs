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
        
        public event Action LeftFireDown;
        public event Action LeftFireUp;
        public event Action RightFireDown;
        public event Action RightFireUp;
        
        public event Action Ability;
        
        public void Update()
        {
            UpdateHorizontalAxis();
            UpdateMousePosition();
            
            JumpInput();

            RightFireInput();
            LeftFireInput();

            AbilityInput();
        }

        private void UpdateHorizontalAxis() => 
            HorizontalAxis = UnityEngine.Input.GetAxis(_horizontalAxis);

        private void UpdateMousePosition() => 
            MousePosition = UnityEngine.Input.mousePosition;

        private void JumpInput()
        {
            if (UnityEngine.Input.GetButtonDown(_jumpButton))
                JumpStart?.Invoke();
            else if (UnityEngine.Input.GetButtonUp(_jumpButton))
                JumpEnd?.Invoke();
        }

        private void RightFireInput()
        {
            if(UnityEngine.Input.GetButtonDown(_rightMouseButton))
                RightFireDown?.Invoke();
            else if(UnityEngine.Input.GetButtonUp(_rightMouseButton))
                RightFireUp?.Invoke();
        }

        private void LeftFireInput()
        {
            if(UnityEngine.Input.GetButtonDown(_leftMouseButton))
                LeftFireDown?.Invoke();
            else if(UnityEngine.Input.GetButtonUp(_leftMouseButton))
                LeftFireUp?.Invoke();
        }

        private void AbilityInput()
        {
            if(UnityEngine.Input.GetButton(_abilityButton))
                Ability?.Invoke();
        }
    }
}
