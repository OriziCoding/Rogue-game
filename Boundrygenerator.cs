using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MonoBehaviour
{
    public Vector2 areaSize = new Vector2(10f, 10f); // Size of the area to cover with boundaries
    public GameObject boundaryPrefab; // Reference to the boundary prefab

    void Start()
    {
        GenerateBoundary();
    }

    void GenerateBoundary()
    {
        // Calculate half sizes for positioning
        float halfWidth = areaSize.x / 2f;
        float halfHeight = areaSize.y / 2f;

        // Instantiate boundaries along the top and bottom edges
        for (float x = -halfWidth; x <= halfWidth; x++)
        {
            InstantiateBoundary(new Vector3(x, halfHeight, 0f)); // Top boundary
            InstantiateBoundary(new Vector3(x, -halfHeight, 0f)); // Bottom boundary
        }

        // Instantiate boundaries along the left and right edges (excluding corners)
        for (float y = -halfHeight + 1; y < halfHeight; y++)
        {
            InstantiateBoundary(new Vector3(-halfWidth, y, 0f)); // Left boundary
            InstantiateBoundary(new Vector3(halfWidth, y, 0f)); // Right boundary
        }
    }

    void InstantiateBoundary(Vector3 position)
    {
        // Instantiate the boundary prefab at the given position
        Instantiate(boundaryPrefab, position, Quaternion.identity, transform);
    }
}
