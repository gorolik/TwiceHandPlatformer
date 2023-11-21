using System;

namespace Sources.Services.Input
{
    public class InputService : IInputService
    {
        private const string _horizontalAxis = "Horizontal";
        private const string _jumpButton = "Jump";

        public float HorizontalAxis { get; private set; }
        public event Action Jump;

        public void Update()
        {
            UpdateHorizontalAxis();
            TryJump();
        }

        private void UpdateHorizontalAxis() => 
            HorizontalAxis = UnityEngine.Input.GetAxis(_horizontalAxis);

        private void TryJump()
        {
            if (UnityEngine.Input.GetButtonDown(_jumpButton))
                Jump?.Invoke();
        }
    }
}
