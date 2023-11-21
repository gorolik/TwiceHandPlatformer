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

        public void Init() => 
            _inputService.Jump += _characterMove.Jump;

        private void OnDestroy() => 
            _inputService.Jump -= _characterMove.Jump;

        private void Update() => 
            _characterMove.Move(_inputService.HorizontalAxis);
    }
}
