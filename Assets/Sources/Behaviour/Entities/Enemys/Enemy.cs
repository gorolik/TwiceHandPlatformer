using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.Entities.Enemys
{
    public class Enemy : MonoBehaviour
    {
        protected PlayerRoot Player;
        protected bool Inited;
        
        public virtual void Init(PlayerRoot player)
        {
            Player = player;
            
            Inited = true;
        }
    }
}