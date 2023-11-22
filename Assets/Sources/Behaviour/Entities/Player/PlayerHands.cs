using Sources.Behaviour.Items;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerHands : MonoBehaviour
    {
        [SerializeField] private CharacterHands _characterHands;
        
        private IInputService _inputService;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.LeftFire += OnLeftFire;
            _inputService.RightFire += OnRightFire;
            
            //_characterHands.TakeItemInRightHand(FindObjectOfType<Sword>()); // Временная замена механики применения лута к игроку в магазине или на старте игры
            //_characterHands.TakeItemInLeftHand(FindObjectOfType<Shield>());
        }

        private void OnLeftFire() => 
            _characterHands.UseLeftHandItem();

        private void OnRightFire() => 
            _characterHands.UseRightHandItem();
    }
}