using System;
using System.Collections.Generic;
using Sources.Behaviour.Entities.Enemys;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Enemy[] _enemys;

        private List<Enemy> _activeEnemies = new List<Enemy>();
        
        public event Action Complete;

        public Vector2 PlayerStartPosition => _playerStartPosition.position;

        public void Run(PlayerRoot player)
        {
            foreach (Enemy enemy in _enemys)
            {
                _activeEnemies.Add(enemy);
                
                enemy.Init(player);
                enemy.Defeated += OnEnemyDefeated;
            }
        }

        private void OnEnemyDefeated(Enemy enemy)
        {
            enemy.Defeated -= OnEnemyDefeated;
            _activeEnemies.Remove(enemy);

            if (_activeEnemies.Count == 0)
                LevelComplete();
        }

        private void LevelComplete() => 
            Complete?.Invoke();
    }
}