using Sources.Behaviour.Entities.HealthSystem;
using Sources.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerRoot : MonoBehaviour
    {
        [Header("Links")] 
        [SerializeField] private PlayerMove _move;
        [SerializeField] private PlayerHands _hands;
        [SerializeField] private PlayerAim _aim;
        [SerializeField] private Transform _observePoint;
        [SerializeField] private Health _health;
        [SerializeField] private PlayerInventory _inventory;

        public Transform ObservePoint => _observePoint;
        public Health Health => _health;
        public PlayerInventory Inventory => _inventory;
        public PlayerAim Aim => _aim;

        public void Construct(IInputService inputService, Camera camera)
        {
            _move.Construct(inputService);
            _hands.Construct(inputService);
            _aim.Construct(inputService, camera);
        }

        public void Init()
        {
            _health.Dead += OnDead;
            
            _move.Init();
            _hands.Init();
            _inventory.Init();
        }

        public void SetControls(bool value)
        {
            _move.CanMove = value;
            _aim.CanAim = value;
        }

        private void OnDestroy() => 
            _health.Dead -= OnDead;

        private void OnDead() => 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}