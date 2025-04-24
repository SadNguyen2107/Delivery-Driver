// PlayerMovement.cs
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Player Movement Settings")]
    [SerializeField] float _linearSpeed = 10f;
    [SerializeField] float _maxLinearSpeed = 20f;
    [SerializeField] float _rotationSpeed = 360f;
    [SerializeField] float _maxRotationSpeed = 720f; // Maximum rotation speed
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
        _rb.linearVelocity = _linearSpeed * _moveInput.y * transform.up;

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

    public void BoostSpeed(float duration, float speedMultiplier)
    {
        // Implement speed boost logic here
        // For example, you can increase _linearSpeed temporarily
        StartCoroutine(SpeedBoostCoroutine(duration, speedMultiplier));
    }

    IEnumerator SpeedBoostCoroutine(float duration, float speedMultiplier)
    {
        float originalLinearSpeed = _linearSpeed;
        float originalRotationSpeed = _rotationSpeed; // Store the original rotation speed
        
        if (_linearSpeed >= _maxLinearSpeed ) yield break; // Prevent boosting if already at max speed            
        if (_rotationSpeed >= _maxRotationSpeed) yield break; // Prevent boosting if already at max rotation speed

        _linearSpeed *= speedMultiplier; // Double the speed for the boost duration
        _rotationSpeed *= speedMultiplier; // Double the rotation speed for the boost duration

        yield return new WaitForSeconds(duration);

        _linearSpeed = originalLinearSpeed; // Reset to original speed
        _rotationSpeed = originalRotationSpeed; // Reset to original rotation speed
    }
}
