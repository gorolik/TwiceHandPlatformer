using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterMove : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 7;
        [SerializeField] private float _jumpForce = 13;
        [SerializeField] private float _maxJumpTime = 0.5f;
        [SerializeField] private float _jumpReleaseMod = 2;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private GroundChecker _groundChecker;
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private CharacterViewDirection _characterViewDirection;


        private enum State { Stay, Walking, Falling }

        private bool _jumping;
        private float _jumpTime;
        private State _state;

        private void Update()
        {
            SetMovementState();
            JumpUpdate();
        }

        public void Move(float horizontal)
        {
            horizontal = Mathf.Clamp(horizontal, -1, 1);
            
            Vector2 direction = new Vector2(horizontal, 0);
            _rigidbody.velocity = new Vector2(direction.x * _moveSpeed, _rigidbody.velocity.y);
        }
        
        public void TryStartJump()
        {
            if (_jumping == false && _groundChecker.IsGrounded())
            {
                _jumpTime = _maxJumpTime;
                _jumping = true;
                
                _characterAnimator.Jump();
            }
        }

        public void EndJump()
        {
            if (_jumping)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y / _jumpReleaseMod);
                
                _jumpTime = 0;
                _jumping = false;
            }
        }

        private void JumpUpdate()
        {
            if(_jumping && _jumpTime > 0) 
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _jumpForce);
                _jumpTime = Mathf.Clamp(_jumpTime - Time.deltaTime, 0, float.MaxValue);

                if (_jumpTime <= 0) 
                    EndJump();
            }
        }

        private void Grounded()
        {
            EndJump();
            _characterAnimator.Grounded();
        }

        private void SetMovementState()
        {
            if (!_groundChecker.IsGrounded())
                HandleFallingState();
            else
                HandleGroundedState();
        }

        private void HandleFallingState()
        {
            if (_state != State.Falling)
            {
                _characterAnimator.Falling();
                SetStateIfDifferent(State.Falling);
            }
        }

        private void HandleGroundedState()
        {
            if (_state == State.Falling) 
                Grounded();

            if (Mathf.Abs(_rigidbody.velocity.x) > 0)
                HandleWalkingState();
            else
                HandleStayState();
        }

        private void HandleWalkingState()
        {
            if (_state != State.Walking)
            {
                _characterAnimator.Move();
                SetStateIfDifferent(State.Walking);
            }

            SetAnimationMoveSpeed();
        }

        private void HandleStayState()
        {
            if (_state != State.Stay)
            {
                _characterAnimator.Stay();
                SetStateIfDifferent(State.Stay);
            }
        }

        private void SetStateIfDifferent(State newState)
        {
            if (_state != newState) 
                _state = newState;
        }

        private void SetAnimationMoveSpeed()
        {
            int direction = 1;

            if (_characterViewDirection.LookDirection == CharacterViewDirection.Direction.Left)
                direction = -1;

            _characterAnimator.SetMoveSpeed(_rigidbody.velocity.x * direction);
        }
    }
}