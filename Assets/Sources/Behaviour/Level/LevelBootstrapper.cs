using Sources.Behaviour.Entities.Player;
using Sources.Infrastructure.DI;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Level
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerRoot _playerPrefab;
        [SerializeField] private Transform _playerSpawnPoint;
        
        private IInputService _inputService;
        
        private void Start()
        {
            _inputService = AllServices.Container.Single<IInputService>();
            
            InitLevel();
        }

        private void InitLevel()
        {
            PlayerRoot player = Instantiate(_playerPrefab, _playerSpawnPoint.position, Quaternion.identity);
            player.Construct(_inputService);
            player.Init();
        }
    }
}