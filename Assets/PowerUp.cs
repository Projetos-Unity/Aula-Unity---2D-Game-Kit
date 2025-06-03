using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gamekit2D;

public class PowerUp : MonoBehaviour
{
    public GameObject pickupEffect; // Assign the power-up prefab in the inspector
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Pickup(other);
        }
    }
    
    void Pickup(Collider2D player)
    {
        Instantiate(pickupEffect, transform.position, transform.rotation);
        // Get Player scale
        Vector3 playerScale = player.transform.localScale;
        // Access Damageable component from the player
        // Assuming the player has a Damageable component, you can access it like this:

        Damageable damageableComponent = player.GetComponent<Damageable>();
        // Example: Increase player's health or apply a power-up effect
        if (damageableComponent != null)
        {   
            Debug.Log("Player has a Damageable component. Current Health: " + damageableComponent.CurrentHealth);
            // Example: Increase health by 1
            //Invoke GainHealth to increase the player's health
            damageableComponent.GainHealth(1);
            // Invoke the OnGainHealth event to notify other systems
            damageableComponent.OnGainHealth.Invoke(1, damageableComponent);
            Debug.Log("Player health increased by 1. Current Health: " + damageableComponent.CurrentHealth);
        }
        else
        {
            Debug.LogWarning("Player does not have a Damageable component.");
        }


        GetComponent<Collider2D>().enabled = false; // Disable the collider to prevent multiple pickups

        // Add power-up logic here, e.g., increase player's speed, health, etc.
        Debug.Log("Power-up picked up by " + player.name);
        
        // Destroy the power-up object after pickup
        Destroy(gameObject);
    }
}
