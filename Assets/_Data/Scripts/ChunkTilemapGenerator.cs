using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ChunkTilemapGenerator : MonoBehaviour
{
    [Header("Map Settings")]
    [SerializeField] int chunkSize = 32;
    [SerializeField] float scale = 10f;

    [Header("Tiles")]
    [SerializeField] RuleTile grassTile;
    [SerializeField] RuleTile water1Tile;

    [Header("Tilemaps")]
    [SerializeField] private Tilemap groundTilemap;
    [SerializeField] private Tilemap waterTilemap;

    [Header("Player")]
    [SerializeField] Transform player;
    [SerializeField] int loadRange = 2;

    private Dictionary<Vector2Int, bool> activeChunks = new();
    private float offsetX, offsetY;

    void Start()
    {
        offsetX = Random.Range(0, 999);
        offsetY = Random.Range(0, 999);
    }

    void Update()
    {
        UpdateChunks();
    }

    void UpdateChunks()
    {
        Vector2Int currentChunk = WorldToChunkPos(player.position);

        HashSet<Vector2Int> neededChunks = new();

        // Load chunks xung quanh player
        for (int cx = -loadRange; cx <= loadRange; cx++)
        {
            for (int cy = -loadRange; cy <= loadRange; cy++)
            {
                Vector2Int chunkCoord = currentChunk + new Vector2Int(cx, cy);
                neededChunks.Add(chunkCoord);

                if (!activeChunks.ContainsKey(chunkCoord))
                {
                    GenerateChunk(chunkCoord);
                    activeChunks[chunkCoord] = true;
                }
            }
        }

        // Unload chunks không cần thiết
        List<Vector2Int> toRemove = new();
        foreach (var chunk in activeChunks.Keys)
        {
            if (!neededChunks.Contains(chunk))
            {
                UnloadChunk(chunk);
                toRemove.Add(chunk);
            }
        }
        foreach (var chunk in toRemove) activeChunks.Remove(chunk);
    }

    void GenerateChunk(Vector2Int chunkCoord)
    {
        Vector3Int startPos = new(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);

        TileBase[] groundTiles = new TileBase[chunkSize * chunkSize];
        TileBase[] waterTiles = new TileBase[chunkSize * chunkSize];

        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                float xCoor = (startPos.x + x) / (float)chunkSize * scale + offsetX;
                float yCoor = (startPos.y + y) / (float)chunkSize * scale + offsetY;

                float noiseValue = Mathf.PerlinNoise(xCoor, yCoor);

                if (noiseValue < 0.25f) // Nước
                {
                    waterTiles[x + y * chunkSize] = water1Tile;
                    groundTiles[x + y * chunkSize] = null;
                }
                else // Cỏ
                {
                    groundTiles[x + y * chunkSize] = grassTile;
                    waterTiles[x + y * chunkSize] = null;
                }
            }
        }

        groundTilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), groundTiles);
        waterTilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), waterTiles);
    }

    void UnloadChunk(Vector2Int chunkCoord)
    {
        Vector3Int startPos = new(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);

        TileBase[] emptyTiles = new TileBase[chunkSize * chunkSize];
        groundTilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), emptyTiles);
        waterTilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), emptyTiles);
    }

    Vector2Int WorldToChunkPos(Vector3 worldPos)
    {
        int cx = Mathf.FloorToInt(worldPos.x / chunkSize);
        int cy = Mathf.FloorToInt(worldPos.y / chunkSize);
        return new Vector2Int(cx, cy);
    }
}
