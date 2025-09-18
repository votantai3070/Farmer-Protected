using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject objectPrefab;
    [SerializeField] private List<GameObject> objectPool = new();
    [SerializeField] int instanceCount = 5;

    private void Start()
    {
        // Pre-instantiate a few arrows to populate the pool
        for (int i = 0; i < instanceCount; i++)
        {
            GameObject obj = Instantiate(objectPrefab);
            obj.SetActive(false);
            objectPool.Add(obj);
        }
    }

    public GameObject Get()
    {
        foreach (var obj in objectPool)
        {
            if (!obj.activeInHierarchy)
            {
                obj.SetActive(true);
                return obj;
            }
        }

        GameObject newObj = Instantiate(objectPrefab);
        newObj.SetActive(true);
        objectPool.Add(newObj);
        return newObj;
    }

    public void ReturnPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
