using Sources.Behaviour.Entities.Player;
using Sources.Behaviour.UI;
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

        [Header("Between levels")] 
        [SerializeField] private CrossLevelMenu _crossLevelMenu;
        
        [Header("Levels")] 
        [SerializeField] private Level[] _levelPrefabs;

        private PlayerRoot _player;
        private Level _loadedLevel;
        private int _currentLevelId;
        
        private IInputService _inputService;
        
        private void Start()
        {
            GetServices();

            LoadAndStartLevel(0);
        }

        private void LoadAndStartLevel(int id)
        {
            if(id >= _levelPrefabs.Length)
                return;
            
            if (_loadedLevel != null)
                UnloadLevel(_loadedLevel);

            _currentLevelId = id;
            _loadedLevel = CreateLevel(id);
            _loadedLevel.Complete += OnLevelComplete;
            
            InitPlayer();

            _loadedLevel.Run(_player);
        }

        private void OnLevelComplete()
        {
            OpenCrossLevelMenu();
            _crossLevelMenu.Closed += OnCrossLevelMenuClosed;
        }

        private void OpenCrossLevelMenu()
        {
            _player.SetControls(false);
            _crossLevelMenu.Open(_player);
        }

        private void OnCrossLevelMenuClosed()
        {
            _crossLevelMenu.Closed -= OnCrossLevelMenuClosed;
            LoadAndStartLevel(_currentLevelId + 1);
            _player.SetControls(true);
        }

        private Level CreateLevel(int id)
        {
            Level levelToCreate = _levelPrefabs[id];
            return Instantiate(levelToCreate);
        }

        private void UnloadLevel(Level level) => 
            Destroy(level.gameObject);

        private void InitPlayer()
        {
            if (_player == null)
                InitPlayer(_loadedLevel.PlayerStartPosition);
            else
                SetPlayerToStartPosition(_loadedLevel.PlayerStartPosition);
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