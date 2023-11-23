using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private CharacterHand[] _hands;
        
        private IInputService _inputService;

        public CharacterHand RightHand => _hands[0];
        public CharacterHand LeftHand => _hands[1];

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.RightFireDown += RightHand.TryBeginUseItem;
            _inputService.RightFireUp += RightHand.TryEndUseItem;
            
            _inputService.LeftFireDown += LeftHand.TryBeginUseItem;
            _inputService.LeftFireUp += LeftHand.TryEndUseItem;
        }

        private void OnDestroy()
        {
            _inputService.RightFireDown -= RightHand.TryBeginUseItem;
            _inputService.RightFireUp -= RightHand.TryEndUseItem;
            
            _inputService.LeftFireDown -= LeftHand.TryBeginUseItem;
            _inputService.LeftFireUp -= LeftHand.TryEndUseItem;
        }
    }
}