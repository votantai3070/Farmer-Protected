using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    public GameObject arrowPrefab;
    [SerializeField] private List<GameObject> arrowPool = new();

    private void Start()
    {
        // Pre-instantiate a few arrows to populate the pool
        for (int i = 0; i < 10; i++)
        {
            GameObject arrow = Instantiate(arrowPrefab);
            arrow.SetActive(false);
            arrowPool.Add(arrow);
        }
    }

    public GameObject GetArrow()
    {
        foreach (var arrow in arrowPool)
        {
            if (!arrow.activeInHierarchy)
            {
                arrow.SetActive(true);
                return arrow;
            }
        }
        // If no inactive arrows are available, instantiate a new one
        GameObject newArrow = Instantiate(arrowPrefab);
        arrowPool.Add(newArrow);
        return newArrow;
    }

    public void ReturnArrow(GameObject arrow)
    {
        arrow.SetActive(false);
    }
}
