using System;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class PlayerInput : MonoBehaviour, IMovementEvents, IAttackEvents
{
    protected InputActions Actions;

    public abstract event Action<Vector2> MovementDirectionUpdated;
    public abstract event Action AttackPressed;

    protected virtual void Awake()
    {
        Actions = new InputActions();

        Actions.KeyboardMouse.Movement.performed += moveDirectionContext =>
        RaiseMovementDirection(moveDirectionContext);
        Actions.KeyboardMouse.Movement.canceled += moveDirectionContext =>
        RaiseMovementDirection(moveDirectionContext);

        Actions.KeyboardMouse.Attack.performed += attackContext => 
        RaiseAttackPressed(attackContext);
    }

    protected virtual void OnEnable()
    {
        Actions.Enable();
    }

    protected virtual void OnDisable()
    {
        Actions.Disable();
    }

    protected abstract void RaiseAttackPressed(InputAction.CallbackContext attackContext);
    protected abstract void RaiseMovementDirection(InputAction.CallbackContext movementcontext);
}