using Sources.Services.Input;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerMove : CharacterMove
    {
        private IInputService _inputService;
        
        public void Construct(IInputService inputService) => 
            _inputService = inputService;

        public void Init()
        {
            _inputService.JumpStart += TryStartJump;
            _inputService.JumpEnd += EndJump;
        }

        private void OnDestroy()
        {
            _inputService.JumpStart -= TryStartJump;
            _inputService.JumpEnd -= EndJump;
        }

        protected override void Update()
        {
            Move(_inputService.HorizontalAxis);
            
            base.Update();
        }
    }
}
