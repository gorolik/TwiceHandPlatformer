using Sources.Behaviour.Items;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    [CreateAssetMenu(menuName = "Scriptable Objects/Item", fileName = "Item", order = 51)]
    public class DescribedItem : DescribedThink
    {
        [SerializeField] private Item _itemPrefab;

        public Item ItemPrefab => _itemPrefab;
    }
}