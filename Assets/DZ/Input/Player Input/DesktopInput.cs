using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class DesktopInput : PlayerInput
{
    public override event Action<Vector2> MovementDirectionUpdated;
    public override event Action AttackPressed;

    protected override void RaiseMovementDirection(InputAction.CallbackContext movementContext)
    {
        if (movementContext.performed)
        {
            MovementDirectionUpdated?.Invoke(movementContext.action.ReadValue<Vector2>());
        }
        else if (movementContext.canceled)
        {
            MovementDirectionUpdated?.Invoke(Vector2.zero);
        }
    }

    protected override void RaiseAttackPressed(InputAction.CallbackContext attackContext)
    {
        if (attackContext.performed)
        {
            AttackPressed?.Invoke();
        }
    }
}
