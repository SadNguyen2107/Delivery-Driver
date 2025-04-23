// PlayerController.cs
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerMovement _playerMovement;
    InputAction _playerMoveAction;

    void Awake()
    {
        FindActions();
    }
    void Start()
    {
        if (!TryGetComponent(out _playerMovement))
        {
            Debug.LogError("PlayerMovement component not found on the player object.");
            return;
        }
    }

    void Update()
    {
        Vector2 moveInput = _playerMoveAction.ReadValue<Vector2>();
        // Assuming you have a PlayerMovement component to handle movement
        _playerMovement.SetMoveInput(moveInput);
    }

    public void FindActions()
    {
        _playerMoveAction = InputSystem.actions.FindAction("Player/Move") ??
            throw new System.Exception("Player/Move action not found in InputActions.");
    }
}
