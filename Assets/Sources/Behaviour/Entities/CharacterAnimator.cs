using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterAnimator : MonoBehaviour
    {
        public static readonly int MoveHash = Animator.StringToHash("Move");
        public static readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
        public static readonly int JumpHash = Animator.StringToHash("Jump");
        public static readonly int FallingHash = Animator.StringToHash("Falling");

        [SerializeField] private Animator _animator;

        public void Move() => 
            _animator.SetBool(MoveHash, true);

        public void Stay() => 
            _animator.SetBool(MoveHash, false);

        public void SetMoveSpeed(float speed) => 
            _animator.SetFloat(MoveSpeedHash, speed);

        public void Jump() => 
            _animator.SetTrigger(JumpHash);
        
        public void Falling() => 
            _animator.SetBool(FallingHash, true);

        public void Grounded() => 
            _animator.SetBool(FallingHash, false);
    }
}