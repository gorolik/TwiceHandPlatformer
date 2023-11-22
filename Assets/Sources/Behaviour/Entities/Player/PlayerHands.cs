using Sources.Services.Input;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerHands : CharacterHands
    {
        private IInputService _inputService;

        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.LeftFire += UseLeftHandItem;
            _inputService.RightFire += UseRightHandItem;
            
            //_characterHands.TakeItemInRightHand(FindObjectOfType<Sword>()); // Временная замена механики применения лута к игроку в магазине или на старте игры
            //_characterHands.TakeItemInLeftHand(FindObjectOfType<Shield>());
        }
    }
}