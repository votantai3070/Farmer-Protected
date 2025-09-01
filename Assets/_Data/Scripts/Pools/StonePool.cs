using System.Collections.Generic;
using UnityEngine;

public class StonePool : MonoBehaviour
{
    public GameObject stonePrefab;
    [SerializeField] private List<GameObject> stonePool = new();

    private void Start()
    {
        // Pre-instantiate a few stones to populate the pool
        for (int i = 0; i < 10; i++)
        {
            GameObject rock = Instantiate(stonePrefab);
            rock.SetActive(false);
            stonePool.Add(rock);
        }
    }
    public GameObject GetStone()
    {
        foreach (var stone in stonePool)
        {
            if (!stone.activeInHierarchy)
            {
                stone.SetActive(true);
                return stone;
            }
        }
        // If no inactive rocks are available, instantiate a new one
        GameObject newRock = Instantiate(stonePrefab);
        stonePool.Add(newRock);
        return newRock;
    }
    public void ReturnRock(GameObject stone)
    {
        stone.SetActive(false);
    }
}
