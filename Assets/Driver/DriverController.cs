using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Driver/DriverController")]
public class DriverController : MonoBehaviour
{
    // Attribute
    [SerializeField] float steer_speed;
    [SerializeField] float move_speed;
    [SerializeField] float slow_speed;
    [SerializeField] float fast_speed;

    // Update is called once per frame
    void Update()
    {
        // Move the player according to the key pressed
        this.MovePlayer();

        Debug.Log(this.move_speed);
    }

    /// <summary>
    ///     For moving player
    /// </summary>
    private void MovePlayer()
    {
        // Get the amount of Turn Left || Turn Right
        float steer_amount = Input.GetAxis("Horizontal");

        // Get the amount of Move Forward || Move Downward
        float move_amount = Input.GetAxis("Vertical");

        // Rotate the player every frame
        transform.Rotate(0, 0, -steer_amount * this.steer_speed * Time.deltaTime);

        // Move the player every frame
        transform.Translate(0, move_amount * this.move_speed * Time.deltaTime, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        this.move_speed = this.slow_speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check If that is the speed up 
        // Then change the speed
        if (other.CompareTag("SpeedUp"))
        {
            this.move_speed = this.fast_speed;
        }
    }
}
