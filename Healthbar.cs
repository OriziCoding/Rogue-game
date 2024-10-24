using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth playerHealth; // Reference to the player's health script
    public Slider healthSlider; // Reference to the UI slider for the health bar
    public float heightAboveHead = 1f; // Height above the player's head

    void Update()
    {
        // Ensure playerHealth and healthSlider references are set
        if (playerHealth == null || healthSlider == null)
        {
            Debug.LogError("Player health or health slider not set in HealthBar script!");
            return;
        }

        // Update the slider's value to match the player's current health
        healthSlider.value = playerHealth.currentHealth;

        // Set the position of the health bar above the player's head
        transform.position = playerHealth.transform.position + Vector3.up * heightAboveHead;
    }
}
