using Sources.Behaviour.Items;
using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public abstract class CharacterHands : MonoBehaviour
    {
        [SerializeField] private Transform _leftHand;
        [SerializeField] private Transform _rightHand;
        
        private Item _leftHandItem;
        private Item _rightHandItem;

        protected void UseLeftHandItem()
        {
            if(_leftHandItem != null)
                _leftHandItem.Use();
        }

        protected void UseRightHandItem()
        {
            if(_rightHandItem != null)
                _rightHandItem.Use();
        }

        protected void TakeItemInLeftHand(Item item) => 
            TakeItem(item, ref _leftHandItem, _leftHand);

        protected void TakeItemInRightHand(Item item) => 
            TakeItem(item, ref _rightHandItem, _rightHand);

        private void TakeItem(Item item, ref Item handSlot, Transform hand)
        {
            if(item.Taken)
                return;
            
            if (handSlot != null) 
                handSlot.Drop();

            handSlot = item;
            item.Take(hand);
        }
    }
}