using System;
using Sources.Infrastructure.Extensions;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerAim : MonoBehaviour
    {
        [SerializeField] private CharacterViewDirection _characterViewDirection;
        [SerializeField] private AimGroup[] _aimGroups;
        
        private IInputService _inputService;
        private Camera _camera;

        public void Construct(IInputService inputService, Camera camera)
        {
            _inputService = inputService;
            _camera = camera;
        }

        private void Update()
        {
            Vector2 aimPoint = _camera.ScreenToWorldPoint(_inputService.MousePosition);
            
            _characterViewDirection.SetCharacterViewToLookDirection(aimPoint.x);
            RotateAimObjectToMousePointer(aimPoint);
        }

        private void RotateAimObjectToMousePointer(Vector2 aimPoint)
        {
            foreach (AimGroup group in _aimGroups)
                group.ToAim.LookAt2D(aimPoint, group.AngleOffset);
        }
        
        [Serializable]
        private struct AimGroup
        {
            public Transform ToAim;
            public float AngleOffset;
        }
    }
}