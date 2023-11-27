using UnityEngine;

namespace Sources.Behaviour.Entities.CharacterParameters
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private WeightParameter _weight;
        [SerializeField] private IntGameParameter _jumpsCount;

        public WeightParameter Weight => _weight;
        public IntGameParameter JumpsCount => _jumpsCount;

        private void Start()
        {
            _weight.Init();
            _jumpsCount.Init();
        }
    }
}