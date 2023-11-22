using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private CharacterMove _characterMove;

        private IInputService _inputService;
        
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.JumpStart += _characterMove.TryStartJump;
            _inputService.JumpEnd += _characterMove.EndJump;
        }

        private void OnDestroy()
        {
            _inputService.JumpStart -= _characterMove.TryStartJump;
            _inputService.JumpEnd -= _characterMove.EndJump;
        }

        private void Update() => 
            _characterMove.Move(_inputService.HorizontalAxis);
    }
}
