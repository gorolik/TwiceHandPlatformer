using Sources.Behaviour.Equipments;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Equipment", fileName = "Equipment", order = 51)]
    public class DescribedEquipment : DescribedThink
    {
        [SerializeField] private Equipment _equipmentPrefab;

        public Equipment EquipmentPrefab => _equipmentPrefab;
    }
}