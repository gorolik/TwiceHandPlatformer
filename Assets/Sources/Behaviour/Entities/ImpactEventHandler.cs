using System;
using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class ImpactEventHandler : MonoBehaviour
    {
        public event Action<bool> ImpactStateChanged;
        
        public void EnableImpact() => 
            ImpactStateChanged?.Invoke(true);

        public void DisableImpact() => 
            ImpactStateChanged?.Invoke(false);
    }
}