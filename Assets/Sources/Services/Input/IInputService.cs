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
        event Action LeftFire;
        event Action RightFire;
        event Action Ability;
        event Action JumpEnd;
    }
}