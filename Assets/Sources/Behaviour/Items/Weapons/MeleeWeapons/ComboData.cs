using System;

namespace Sources.Behaviour.Items.Weapons.MeleeWeapons
{
    [Serializable]
    public class ComboData
    {
        public Stage[] Stages;
            
        [Serializable]
        public class Stage
        {
            public float DamageRatio = 1;
            public float PushForce = 0;
            public float ContinueDelay = 0.2f;
            public float ContinueTime = 0.4f;
        }
    }
}