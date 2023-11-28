using Sources.Behaviour.Entities.CharacterParameters;
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
        [SerializeField] private CharacterData _characterData;
        
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
        
        public void TryTakeItem(Item item)
        {
            if(item.Taken)
                return;
            
            TryDropItem();

            _item = item;
            item.Take(_itemParent, this);
            
            _characterData.Weight.AddBonus(item.Weight);
        }

        private void TryDropItem()
        {
            if (_item == null)
                return;

            _characterData.Weight.AddBonus(-_item.Weight);
            _item.Drop();
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