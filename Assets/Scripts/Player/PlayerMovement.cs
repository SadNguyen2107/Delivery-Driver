// PlayerMovement.cs
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] float _moveSpeed = 10f;
    [SerializeField] float _rotationSpeed = 360f;
    Rigidbody2D _rb;
    Vector2 _moveInput;

    void Awake()
    {
        if (!TryGetComponent(out _rb))
        {
            Debug.LogError("Rigidbody2D component not found on the player object.");
            return;
        }
    }

    void FixedUpdate()
    {
        _rb.linearVelocity = _moveSpeed * _moveInput.y * transform.up;

        // Can rotate if the player is moving forward or backward
        if (_moveInput.y != 0f || _moveInput.x == 0f)
        {
            _rb.angularVelocity = _rotationSpeed * _moveInput.x * -1f;
        }

    }
    public void SetMoveInput(Vector2 moveInput)
    {
        _moveInput = moveInput.normalized;
    }
}
