using Sources.Behaviour.Entities.HealthSystem;
using Sources.Behaviour.Items;
using Sources.Services.Input;
using UnityEngine;
using UnityEngine.Serialization;

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
        [SerializeField] private Transform _observePoint;
        [SerializeField] private Health _health;

        public Transform ObservePoint => _observePoint;
        public Health Health => _health;

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
                _hands.RightHand.TryTakeItem(Instantiate(_startRightHandItem));
            if (_startLeftHandItem != null)
                _hands.LeftHand.TryTakeItem(Instantiate(_startLeftHandItem));
        }
    }
}