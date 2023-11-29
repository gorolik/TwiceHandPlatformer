using UnityEngine;

namespace Sources.Behaviour.Equipments.Boots
{
    public abstract class BootsEquipment : Equipment
    {
        [SerializeField] private Transform _leftBoot;
        [SerializeField] private Transform _rightBoot;

        public Transform LeftBoot => _leftBoot;
        public Transform RightBoot => _rightBoot;
    }
}