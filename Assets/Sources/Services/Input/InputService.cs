using System;

namespace Sources.Services.Input
{
    public class InputService : IInputService
    {
        private const string _horizontalAxis = "Horizontal";
        private const string _jumpButton = "Jump";
        private const string _interactionButton = "Interaction";
        private const string _leftMouseButton = "Fire1";
        private const string _rightMouseButton = "Fire2";
        
        public float HorizontalAxis { get; private set; }
        public event Action Jump;
        public event Action PickUpItemInLeftHand;
        public event Action PickUpItemInRightHand;


        public void Update()
        {
            UpdateHorizontalAxis();
            TryJump();
            TryPickUpItemInLeftHand();
            TryPickUpItemInRightHand();
        }

        private void UpdateHorizontalAxis() => 
            HorizontalAxis = UnityEngine.Input.GetAxis(_horizontalAxis);

        private void TryJump()
        {
            if (UnityEngine.Input.GetButtonDown(_jumpButton))
                Jump?.Invoke();
        }

        private void TryPickUpItemInLeftHand()
        {
            if (UnityEngine.Input.GetButton(_interactionButton) && UnityEngine.Input.GetButtonDown(_leftMouseButton))
                PickUpItemInLeftHand?.Invoke();
        }
        
        private void TryPickUpItemInRightHand()
        {
            if (UnityEngine.Input.GetButton(_interactionButton) && UnityEngine.Input.GetButtonDown(_rightMouseButton))
                PickUpItemInRightHand?.Invoke();
        }
    }
}
