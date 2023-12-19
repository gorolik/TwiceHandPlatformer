using UnityEngine;

namespace Sources.Behaviour.Equipments.Gloves
{
    public class GlovesEquipment : Equipment
    {
        [SerializeField] private Transform _leftGlove;
        [SerializeField] private Transform _rightGlove;

        public Transform LeftGlove => _leftGlove;
        public Transform RightGlove => _rightGlove;
    }
}