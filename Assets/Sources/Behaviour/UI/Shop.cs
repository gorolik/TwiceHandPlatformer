using Sources.Behaviour.Entities.Player;
using UnityEngine;

namespace Sources.Behaviour.UI
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private ShopSlot[] _slots;
        [SerializeField] private DescribedThink[] _itemsPool;

        public void Init(PlayerRoot playerRoot)
        {
            for (int i = 0; i < 4; i++)
            {
                int id = Random.Range(0, _itemsPool.Length);
                _slots[i].SetItem(_itemsPool[id]);
                _slots[i].Init(playerRoot);
            }
        }
    }
}
