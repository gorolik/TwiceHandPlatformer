using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.Shields
{
    public class ShieldAnimator : ItemAnimator
    {
        public static readonly int ProtectionHash = Animator.StringToHash("Protection");
        public static readonly int PushHash = Animator.StringToHash("Push");

        public void Protection(bool value) =>
            Animator.SetBool(ProtectionHash, value);
        
        public void Push() =>
            Animator.SetTrigger(PushHash);
    }
}