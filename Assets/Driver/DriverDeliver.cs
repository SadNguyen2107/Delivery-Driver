using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Driver/DriverDeliver")]
public class DriverDeliver : MonoBehaviour
{
    // Check Whether has a Package or not
    private bool hasPackage = false;

    // Player SpriteRenderer
    private SpriteRenderer player_sprite_renderer;

    // The Second to delay after pick up to destroy that package
    [SerializeField] float delay_to_destroy;

    //! Tags
    [SerializeField] string[] tags =
    {
        "Package",
        "Customer"
    };

    //! Sprites corresponding to the Tags
    [SerializeField] Sprite[] player_sprites;

    void Start()
    {
        // Get the SpriteRenderer component of the GameObject
        player_sprite_renderer = GetComponent<SpriteRenderer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if that is a Package
        if (other.CompareTag(this.tags[0]) && !this.hasPackage)
        {
            Debug.Log("Package pick up!");

            // Pick up the Package
            this.hasPackage = true;

            // Change the Color of the player
            this.ChangePlayerSprite(0);

            // Destroy the Package
            Destroy(other.gameObject, this.delay_to_destroy);
        }
        // If has Package and the deliver place is the customer
        else if (other.CompareTag(this.tags[1]) && this.hasPackage)
        {
            Debug.Log("Deliver to the Customer!");

            // Deliever To the Customer
            this.hasPackage = false;

            // Change the Color of the player
            this.ChangePlayerSprite(1);
        }
    }

    void ChangePlayerSprite(int tag_index)
    {
        // Check whether SpriteRender Component Exists
        if (player_sprite_renderer != null && this.player_sprites[tag_index] != null)
        {
            // Check the Sprite according to the tag_index
            player_sprite_renderer.sprite = this.player_sprites[tag_index];
        }
    }
}
