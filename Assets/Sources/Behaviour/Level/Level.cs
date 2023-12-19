using Sources.Behaviour.Entities.Enemys;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Level
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private Enemy[] _enemys;

        public Vector2 PlayerStartPosition => _playerStartPosition.position;

        public void Run(PlayerRoot player)
        {
            foreach (Enemy enemy in _enemys) 
                enemy.Init(player);
        }
    }
}