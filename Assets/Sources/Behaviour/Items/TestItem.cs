using UnityEngine;

namespace Sources.Behaviour.Items
{
    public class TestItem : Item
    {
        public override void Use()
        {
            Debug.Log(gameObject.name + " Used");
        }
    }
}