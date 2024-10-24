using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // Maximum health of the enemy
    private int currentHealth; // Current health of the enemy

    void Start()
    {
        currentHealth = maxHealth; // Initialize current health to maximum health
    }

    // Function to apply damage to the enemy
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount; // Reduce current health by the damage amount

        // Check if the enemy's health has reached zero
        if (currentHealth <= 0)
        {
            Die(); // If health is zero or less, call the Die function
        }
    }

    // Function to handle enemy death
    void Die()
    {
        // Perform death behavior (e.g., play death animation, spawn particles, etc.)
        Destroy(gameObject); // Destroy the enemy GameObject
    }
}
