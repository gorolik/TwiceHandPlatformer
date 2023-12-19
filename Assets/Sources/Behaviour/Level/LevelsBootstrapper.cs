using Sources.Behaviour.Entities.Player;
using Sources.Infrastructure.DI;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Level
{
    public class LevelsBootstrapper : MonoBehaviour
    {
        [Header("Player")]
        [SerializeField] private PlayerRoot _playerPrefab;
        
        [Header("Scene")] 
        [SerializeField] private Camera _camera;
        
        [Header("Levels")] 
        [SerializeField] private Level[] _levelPrefabs;

        private PlayerRoot _player;
        
        private IInputService _inputService;
        
        private void Start()
        {
            GetServices();

            Level level = CreateLevel();
            
            if(_player == null)
                InitPlayer(level.PlayerStartPosition);
            else
                SetPlayerToStartPosition(level.PlayerStartPosition);
            
            level.Run(_player);
        }

        private Level CreateLevel()
        {
            Level levelToCreate = _levelPrefabs[0];
            return Instantiate(levelToCreate);
        }

        private void SetPlayerToStartPosition(Vector2 startPosition) => 
            _player.transform.position = startPosition;

        private void InitPlayer(Vector2 startPosition)
        {
            _player = Instantiate(_playerPrefab, startPosition, Quaternion.identity);
            _player.Construct(_inputService, _camera);
            _player.Init();
        }

        private void GetServices() => 
            _inputService = AllServices.Container.Single<IInputService>();
    }
}