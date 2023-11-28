using UnityEngine;

namespace Sources.Behaviour.Entities.CharacterParameters
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private WeightParameter _weight;
        [SerializeField] private IntGameParameter _jumpsCount;
        [SerializeField] private FloatGameParameter _bounceDamage;

        public WeightParameter Weight => _weight;
        public IntGameParameter JumpsCount => _jumpsCount;
        public FloatGameParameter BounceDamage => _bounceDamage;

        private void Start()
        {
            _weight.Init();
            _jumpsCount.Init();
            _bounceDamage.Init();
        }
    }
}