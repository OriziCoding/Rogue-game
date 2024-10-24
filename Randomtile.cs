using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour
{
    public Tilemap tilemap; // Reference to the Tilemap component
    public TileBase[] tiles; // Array of tiles to randomly select from
    public int generateDistance = 5; // Distance around the player to generate tiles

    private Transform playerTransform; // Reference to the player's transform

    void Start()
    {
        playerTransform = transform; // Assuming this script is attached to the player GameObject
    }

    void Update()
    {
        // Get the player's current position
        Vector3Int playerTilePosition = tilemap.WorldToCell(playerTransform.position);

        // Generate tiles around the player within the specified distance
        for (int x = -generateDistance; x <= generateDistance; x++)
        {
            for (int y = -generateDistance; y <= generateDistance; y++)
            {
                // Calculate the position of the tile relative to the player
                Vector3Int tilePosition = new Vector3Int(playerTilePosition.x + x, playerTilePosition.y + y, playerTilePosition.z);

                // Check if the tile at this position already exists
                if (tilemap.GetTile(tilePosition) == null)
                {
                    // Select a random tile from the array
                    TileBase randomTile = tiles[Random.Range(0, tiles.Length)];

                    // Place the random tile at the calculated position
                    tilemap.SetTile(tilePosition, randomTile);
                }
            }
        }
    }
}

