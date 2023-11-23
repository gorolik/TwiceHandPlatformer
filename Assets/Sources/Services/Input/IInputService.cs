using System;
using Sources.Infrastructure;
using Sources.Infrastructure.DI;
using UnityEngine;

namespace Sources.Services.Input
{
    public interface IInputService : IService, IUpdatable
    {
        float HorizontalAxis { get; }
        Vector2 MousePosition { get; }
        
        event Action JumpStart;
        event Action JumpEnd;
        
        event Action LeftFireDown;
        event Action LeftFireUp;
        event Action RightFireDown;
        event Action RightFireUp;
        
        event Action Ability;
    }
}