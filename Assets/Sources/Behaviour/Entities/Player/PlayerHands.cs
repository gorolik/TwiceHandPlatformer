using System;
using Sources.Behaviour.Items;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private CharacterHands _characterHands;
        private Item _testItemReference;
        
        private IInputService _inputService;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.PickUpItemInLeftHand += TryPickUpItemInLeftHand;
            _inputService.PickUpItemInRightHand += TryPickUpItemInRightHand;

            _testItemReference = FindObjectOfType<Item>(); // Временная замена механики поиска лута
        }

        private void Update() // Временный метод для проверки
        {
            if(Input.GetKeyDown(KeyCode.G))
                _testItemReference.Drop();
        }

        private void OnDestroy()
        {
            _inputService.PickUpItemInLeftHand -= TryPickUpItemInLeftHand;
            _inputService.PickUpItemInRightHand -= TryPickUpItemInRightHand;
        }

        private void TryPickUpItemInLeftHand() => 
            _characterHands.TakeItemInLeftHand(_testItemReference);

        private void TryPickUpItemInRightHand() => 
            _characterHands.TakeItemInRightHand(_testItemReference);
    }
}