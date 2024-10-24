using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public Animator animator; // Reference to the Animator component

    private bool isDead = false; // Boolean to track whether the player is dead
    public float restartDelay = 2f; // Delay before restarting the game

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    public void TakeDamage(int damage)
    {
        if (!isDead) // Check if the player is not already dead
        {
            currentHealth -= damage;
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth); // Ensure health doesn't go below 0 or above maxHealth

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    void Die()
    {
        // Set isDead to true to prevent further actions
        isDead = true;

        // Trigger the death animation
        animator.SetBool("IsDead", true);

        // Reload the current scene to restart the game
        Invoke("ReloadScene", restartDelay);
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
