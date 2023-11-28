using Sources.Behaviour.Entities.CharacterParameters;
using Sources.Behaviour.Entities.HealthSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Behaviour.Entities
{
    public abstract class CharacterMove : MonoBehaviour
    {
        private const float _jumpRoughness = 8;
        private const float _massInfluence = 10;
        private const float _massOffset = 50;
        private const float _minSpeed = 1;
        
        [SerializeField] private float _moveSpeed = 14;
        [SerializeField] private float _jumpForce = 1300;
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CharacterData _characterData;
        [SerializeField] private GroundChecker _groundChecker;
        [FormerlySerializedAs("_overCharacterChecker")] [SerializeField] private BounceOverCharacter _bounceOverCharacter;
        [SerializeField] private CharacterAnimator _characterAnimator;
        [SerializeField] private CharacterViewDirection _characterViewDirection;


        private enum State { Stay, Walking, Falling }

        private float _jumpMargin;
        private int _jumps;
        private bool _jumping;
        private State _state;

        protected virtual void Update()
        {
            SetMovementState();
            JumpUpdate();
        }

        protected void Move(float horizontal)
        {
            horizontal = Mathf.Clamp(horizontal, -1, 1);
            
            Vector2 direction = new Vector2(horizontal, 0);
            float speed = Mathf.Clamp(_moveSpeed - (_characterData.Weight.CurrentValue - _massOffset) / _massInfluence, _minSpeed, float.MaxValue);
            
            _rigidbody.velocity = new Vector2(direction.x * speed, _rigidbody.velocity.y);
        }
        
        protected void TryStartJump()
        {
            if (CanJump())
            {
                if(_state != State.Falling)
                    _jumps = _characterData.JumpsCount.CurrentValue;
                
                _jumps--;
                _jumpMargin = _jumpForce;
                _jumping = true;

                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
                
                _characterAnimator.Jump();
            }
        }

        protected void EndJump()
        {
            if (_jumping)
            {
                _jumpMargin = 0;
                _jumping = false;
            }
        }

        private void JumpUpdate()
        {
            if(_jumping && _jumpMargin > 0)
            {
                _rigidbody.AddForce(new Vector2(0, _jumpForce * _jumpRoughness * Time.deltaTime), ForceMode2D.Impulse);
                
                _jumpMargin -= _jumpForce * _jumpRoughness * Time.deltaTime;

                if (_jumpMargin <= 0) 
                    EndJump();
            }
        }

        private void OnGrounded()
        {
            _jumps = 0;
            EndJump();
            _characterAnimator.Grounded();
        }

        private bool CanJump()
        {
            if (_jumping == false && _groundChecker.IsGrounded())
                return true;
            else if(_jumps > 0)
                return true;
            else if (_bounceOverCharacter.TryBounceOverCharacter())
            {
                _jumps = Mathf.Clamp(_jumps + 1, 0, _characterData.JumpsCount.CurrentValue);
                return true;
            }
            else
                return false;
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
                OnGrounded();

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