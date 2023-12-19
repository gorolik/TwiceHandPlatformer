using UnityEngine;

namespace Sources.Behaviour.Equipments.Boots
{
    public class BootsEquipment : Equipment
    {
        [SerializeField] private Transform _leftBoot;
        [SerializeField] private Transform _rightBoot;

        public Transform LeftBoot => _leftBoot;
        public Transform RightBoot => _rightBoot;
    }
}