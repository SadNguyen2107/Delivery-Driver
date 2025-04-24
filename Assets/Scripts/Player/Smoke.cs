// Smoke.cs
using UnityEngine;

public class Smoke : MonoBehaviour
{
    GameObject _playerGameObject;
    [SerializeField] float _offsetDistance = 0.5f; // Distance from the player
    void Start()
    {        
        _playerGameObject = GameObject.FindGameObjectWithTag("Player") ??
            throw new System.Exception("Player object not found in the scene.");
    }

    void Update()
    {
        FollowPlayer();       
    }

    void FollowPlayer()
    {
        if (_playerGameObject == null) return;

        Vector3 playerPosition = _playerGameObject.transform.position;
        Vector3 playerDirection = _playerGameObject.transform.up;

        transform.forward = playerDirection * -1; // Invert the direction to face the opposite way
        transform.position = playerPosition + playerDirection * _offsetDistance;
    }
}
