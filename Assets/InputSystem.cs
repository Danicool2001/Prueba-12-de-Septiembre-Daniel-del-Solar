using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystem : MonoBehaviour
{
    public static event System.Action OnPause;
    public static event System.Action<bool> OnJump;
    public static event System.Action<Vector2> OnPlayerMovement;

    [SerializeField] private PlayerInput playerInput;

    private void OnEnable()
    {
        playerInput.onActionTriggered += HandleInput;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= HandleInput;
    }

    private void HandleInput(InputAction.CallbackContext context)
    {
        string action = context.action.name;

        switch (action)
        {
            case "Walking":

                Vector2 input = context.ReadValue<Vector2>();
                OnPlayerMovement?.Invoke(input);
                break;

            case "Jump":

                 OnJump?.Invoke(context.ReadValueAsButton());
                break;

            case "Pause": if (context.started) OnPause?.Invoke(); break;
        }
    }
}
