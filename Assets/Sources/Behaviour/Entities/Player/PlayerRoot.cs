using Sources.Behaviour.Items;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerRoot : MonoBehaviour
    {
        [Header("Setup")] 
        [SerializeField] private Item _startLeftHandItem;
        [SerializeField] private Item _startRightHandItem;
        [Header("Links")] 
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

            if (_startRightHandItem != null)
                _hands.RightHand.TakeItem(Instantiate(_startRightHandItem));
            if (_startLeftHandItem != null)
                _hands.LeftHand.TakeItem(Instantiate(_startLeftHandItem));
        }
    }
}