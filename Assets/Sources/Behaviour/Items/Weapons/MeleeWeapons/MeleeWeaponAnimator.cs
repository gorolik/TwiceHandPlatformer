using UnityEngine;

namespace Sources.Behaviour.Items.Weapons.MeleeWeapons
{
    public class MeleeWeaponAnimator : ItemAnimator
    {
        public static readonly int StageHash = Animator.StringToHash("Stage");

        public void SetStage(int value) =>
            Animator.SetInteger(StageHash, value);
    }
}