using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    PlayerControls inputs;

    public float moveDir;

    public EventHandler OnJumpEvent;

    public EventHandler OnAttackEvent;

    private void OnEnable()
    {
        if (inputs == null)
        {
            inputs = new PlayerControls();
            inputs.Player.Move.performed += i => moveDir = i.ReadValue<float>();
            inputs.Player.OnJumpEvent.performed += i => OnJumpEvent.Invoke(this, EventArgs.Empty);
            inputs.Player.Attack.performed += i => OnAttackEvent.Invoke(this, EventArgs.Empty);
        }
        inputs.Enable();
    }
}