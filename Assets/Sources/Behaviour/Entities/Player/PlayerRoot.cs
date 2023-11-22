using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerRoot : MonoBehaviour
    {
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerHands _hands;
        [SerializeField] private PlayerAim _aim;
        
        public void Construct(IInputService inputService, Camera camera)
        {
            _move.Construct(inputService);
            _hands.Construct(inputService);
            _aim.Construct(inputService, camera);
        }

        public void Init()
        {
            _move.Init();
            _hands.Init();
        }
    }
}