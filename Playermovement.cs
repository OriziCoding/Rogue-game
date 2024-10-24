using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Boundary boundary; // Reference to the boundary area

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Calculate the player's next position
        Vector2 nextPosition = rb.position + movement * moveSpeed * Time.fixedDeltaTime;

        // Clamp the next position to the boundary area
        nextPosition.x = Mathf.Clamp(nextPosition.x, boundary.minX, boundary.maxX);
        nextPosition.y = Mathf.Clamp(nextPosition.y, boundary.minY, boundary.maxY);

        // Move the player to the clamped position
        rb.MovePosition(nextPosition);
    }

    public bool IsMoving()
    {
        return movement.magnitude != 0;
    }

    public Vector2 GetMovementDirection()
    {
        return movement;
    }
}

[System.Serializable]
public class Boundary
{
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;
}
