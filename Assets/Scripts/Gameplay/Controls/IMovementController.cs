using System;

namespace Gameplay.Controls
{
    public interface IMovementController//
    {
        float XMove { get; }
        float YMove { get; }
        
        Action OnShootPressed { get; set; }
        Action OnKidnapPressed { get; set; }
    }
}