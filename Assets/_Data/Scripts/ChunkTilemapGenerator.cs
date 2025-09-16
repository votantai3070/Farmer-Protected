using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

public class ChunkTilemapGenerator : MonoBehaviour
{
    [Header("Map Settings")]
    [SerializeField] int chunkSize = 32;    // số ô mỗi chunk
    [SerializeField] float scale = 10f;

    [SerializeField] RuleTile grassTile;
    [SerializeField] RuleTile sandTile;
    [SerializeField] RuleTile water1Tile;
    [SerializeField] RuleTile water2Tile;

    [Header("Player")]
    [SerializeField] Transform player;   // tham chiếu tới player
    [SerializeField] int loadRange = 2;  // số chunk xung quanh player

    private Tilemap tilemap;
    private Dictionary<Vector2Int, bool> activeChunks = new();

    float offsetX, offsetY;

    void Awake()
    {
        tilemap = GetComponent<Tilemap>();
    }

    void Start()
    {
        offsetX = Random.Range(0, 9999);
        offsetY = Random.Range(0, 9999);
    }

    void Update()
    {
        UpdateChunks();
    }

    void UpdateChunks()
    {
        Vector2Int currentChunk = WorldToChunkPos(player.position);

        HashSet<Vector2Int> neededChunks = new();

        // Xác định tất cả chunk cần load
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

        // Unload những chunk không cần thiết nữa
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
        Vector3Int startPos = new Vector3Int(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);

        TileBase[] tileArray = new TileBase[chunkSize * chunkSize];

        for (int x = 0; x < chunkSize; x++)
        {
            for (int y = 0; y < chunkSize; y++)
            {
                float xCoor = (startPos.x + x) / (float)chunkSize * scale + offsetX;
                float yCoor = (startPos.y + y) / (float)chunkSize * scale + offsetY;

                float noiseValue = Mathf.PerlinNoise(xCoor, yCoor);

                RuleTile tileToPlace;
                if (noiseValue < 0.25f) tileToPlace = water1Tile;
                else if (noiseValue < 0.35f) tileToPlace = water2Tile;
                else if (noiseValue < 0.5f) tileToPlace = sandTile;
                else tileToPlace = grassTile;

                tileArray[x + y * chunkSize] = tileToPlace;
            }
        }

        tilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), tileArray);
    }

    void UnloadChunk(Vector2Int chunkCoord)
    {
        Vector3Int startPos = new Vector3Int(chunkCoord.x * chunkSize, chunkCoord.y * chunkSize, 0);

        // Clear chunk bằng cách set toàn bộ tile = null
        TileBase[] emptyTiles = new TileBase[chunkSize * chunkSize];
        tilemap.SetTilesBlock(new BoundsInt(startPos, new Vector3Int(chunkSize, chunkSize, 1)), emptyTiles);
    }

    Vector2Int WorldToChunkPos(Vector3 worldPos)
    {
        int cx = Mathf.FloorToInt(worldPos.x / chunkSize);
        int cy = Mathf.FloorToInt(worldPos.y / chunkSize);
        return new Vector2Int(cx, cy);
    }
}
