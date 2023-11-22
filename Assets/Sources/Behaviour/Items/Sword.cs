using UnityEngine;

namespace Sources.Behaviour.Items
{
    public class Sword : Item
    {
        public override void Use()
        {
            Debug.Log("Using " + gameObject.name);
        }
    }
}