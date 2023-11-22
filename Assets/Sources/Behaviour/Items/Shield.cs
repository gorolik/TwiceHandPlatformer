using UnityEngine;

namespace Sources.Behaviour.Items
{
    public class Shield : Item
    {
        public override void Use()
        {
            Debug.Log("Using " + gameObject.name);
        }
    }
}