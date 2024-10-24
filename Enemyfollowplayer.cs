using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float moveSpeed = 3f; // Movement speed of the enemy
    public Transform target; // Target to follow (e.g., player)
    public int damageAmount = 10; // Amount of damage dealt to the player
    public float attackCooldown = 2f; // Cooldown between enemy attacks

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private bool canAttack = true; // Flag to track if the enemy can currently attack
    private float lastAttackTime; // Timestamp of the last attack

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Check if target is set
        if (target != null)
        {
            // Calculate direction towards the target
            Vector2 moveDirection = (target.position - transform.position).normalized;

            // Move the enemy towards the target
            rb.velocity = moveDirection * moveSpeed;

            // Check if player is on the left side of the enemy
            if (target.position.x < transform.position.x)
            {
                // Flip the enemy to face the player
                spriteRenderer.flipX = true;
            }
            else
            {
                // Ensure the enemy faces the player
                spriteRenderer.flipX = false;
            }
        }
    }

    // Triggered when the enemy stays in contact with another collider (e.g., the player)
    void OnTriggerStay2D(Collider2D other)
    {
        // Check if the collision is with the player and the enemy can attack
        if (other.CompareTag("Player") && canAttack)
        {
            // Deal damage to the player
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damageAmount);
            }

            // Start the cooldown timer for the next attack
            canAttack = false;
            Invoke("ResetAttack", attackCooldown);
        }
    }

    void ResetAttack()
    {
        // Set canAttack to true to allow the enemy to attack again
        canAttack = true;
    }
}
