using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Camera/CameraFollower")]
public class CameraFollower : MonoBehaviour
{
    // Camera Height Perspective to the Background
    [SerializeField] float camera_height;

    // this things position (camera) should be the same as the car's position
    [SerializeField] Transform player_transform;

    // Update is called once per frame
    void LateUpdate()
    {
        // Update the position of the camera to follow the player
        Vector3 player_position = player_transform.position;

        // Change the Vector Z to equal camera_height
        player_position.z = this.camera_height;

        // Update the Camera Position
        transform.position = player_position;
    }
}
