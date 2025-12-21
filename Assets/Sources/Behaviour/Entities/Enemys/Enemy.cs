using System;
using Sources.Behaviour.Entities.HealthSystem;
using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] protected Health Health;
        
        protected PlayerRoot Player;
        protected bool Inited;

        public event Action<Enemy> Defeated;
        
        public virtual void Init(PlayerRoot player)
        {
            Player = player;
            
            Health.Dead += Defeat;
            
            Inited = true;
        }

        private void Defeat()
        {
            Health.Dead -= Defeat;
            Defeated?.Invoke(this);
        }
    }
}