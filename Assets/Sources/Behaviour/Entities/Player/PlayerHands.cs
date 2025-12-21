using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private CharacterHand _leftHand;
        [SerializeField] private CharacterHand _rightHand;

        private IInputService _inputService;
        
        public CharacterHand LeftHand => _leftHand;
        public CharacterHand RightHand => _rightHand;
        
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.RightFireDown += _leftHand.TryBeginUseItem;
            _inputService.RightFireUp += _leftHand.TryEndUseItem;
            
            _inputService.LeftFireDown += _rightHand.TryBeginUseItem;
            _inputService.LeftFireUp += _rightHand.TryEndUseItem;
        }

        private void OnDestroy()
        {
            _inputService.RightFireDown -= _leftHand.TryBeginUseItem;
            _inputService.RightFireUp -= _leftHand.TryEndUseItem;
            
            _inputService.LeftFireDown -= _rightHand.TryBeginUseItem;
            _inputService.LeftFireUp -= _rightHand.TryEndUseItem;
        }
    }
}