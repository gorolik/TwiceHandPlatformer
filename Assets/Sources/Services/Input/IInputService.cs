using System;
using Sources.Infrastructure;
using Sources.Infrastructure.DI;

namespace Sources.Services.Input
{
    public interface IInputService : IService, IUpdatable
    {
        float HorizontalAxis { get; }
        event Action Jump;
    }
}