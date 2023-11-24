using Sources.Behaviour.Items;
using UnityEngine;

namespace Sources.Behaviour.Entities
{
    public class CharacterHand : MonoBehaviour
    {
        [SerializeField] private CharacterViewDirection _characterViewDirection;
        [SerializeField] private Transform _itemParent;
        [SerializeField] private ImpactEventHandler _eventHandler;
        [SerializeField] private Animator _animator;
        
        private Item _item;

        public Animator Animator => _animator;
        public ImpactEventHandler EventHandler => _eventHandler;

        private void OnEnable() => 
            _characterViewDirection.DirectionChanged += SyncDirection;

        private void OnDisable() => 
            _characterViewDirection.DirectionChanged -= SyncDirection;
        
        public void TryBeginUseItem()
        {
            if(_item != null)
                _item.UseBegin();
        }
        
        public void TryEndUseItem()
        {
            if(_item != null)
                _item.UseEnd();
        }
        
        public void TakeItem(Item item)
        {
            if(item.Taken)
                return;
            
            if (_item != null) 
                _item.Drop();

            _item = item;
            item.Take(_itemParent, this);
        }
        
        private void SyncDirection(CharacterViewDirection.Direction direction)
        {
            if (direction == CharacterViewDirection.Direction.Right) 
                transform.localScale = new Vector2(1, 1);
            else
                transform.localScale = new Vector2(-1, -1);
        }
    }
}