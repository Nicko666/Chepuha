using System;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    Controls controls;

    public Action OnEscape;
    public Action OnEscapeHold;

    private void OnEnable()
    {
        controls = new Controls();
        controls.Enable();
        controls.Actionmap.Escape.performed += OnEscapePerformed;
        controls.Actionmap.EscapeHold.performed += OnEscapeHoldPerformed;
    }

    void OnEscapePerformed(InputAction.CallbackContext context) => OnEscape?.Invoke();
    void OnEscapeHoldPerformed(InputAction.CallbackContext context) => OnEscapeHold?.Invoke();

    private void OnDisable()
    {
        controls.Actionmap.Escape.canceled -= OnEscapePerformed;
        controls.Actionmap.EscapeHold.started -= OnEscapeHoldPerformed;
        controls.Disable();
    }


}
