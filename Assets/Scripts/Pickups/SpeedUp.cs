// SpeedUp.cs
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    [SerializeField] float _pushForce = 10f; // Force to apply to the player when they pick up the speed boost
    [SerializeField] float _duration = 5f; // Duration of the speed boost
    [SerializeField] float _speedMultiplier = 2f; // Speed multiplier for the boost
    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        // Get the Rigidbody2D component of the player
        Rigidbody2D playerRigidbody = other.attachedRigidbody;
        if (playerRigidbody == null) return;

        // Apply a force to the player in the direction they are facing
        Vector2 forceDirection = other.transform.up * _pushForce;
        playerRigidbody.AddForce(forceDirection, ForceMode2D.Impulse);

        // Optionally, you can also apply a speed boost effect here
        if (other.TryGetComponent<PlayerMovement>(out var playerMovement))
        {
            playerMovement.BoostSpeed(_duration, _speedMultiplier);
        }
    }
}
