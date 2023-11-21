using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerRoot : MonoBehaviour
    {
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerHands _hands;
        
        public void Construct(IInputService inputService)
        {
            _move.Construct(inputService);
            _hands.Construct(inputService);
        }

        public void Init()
        {
            _move.Init();
            _hands.Init();
        }
    }
}