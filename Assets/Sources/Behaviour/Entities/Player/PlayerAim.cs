using Sources.Infrastructure.Extensions;
using Sources.Services.Input;
using UnityEngine;

namespace Sources.Behaviour.Entities.Player
{
    public class PlayerAim : MonoBehaviour
    {
        private const int _aimAngleOffset = 180;

        [SerializeField] private CharacterViewDirection _characterViewDirection;
        [SerializeField] private Transform[] _toAim;
        
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
            foreach (Transform toAim in _toAim)
                toAim.LookAt2D(aimPoint, _aimAngleOffset);
        }
    }
}