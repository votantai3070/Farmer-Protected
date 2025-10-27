using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    [SerializeField] int poolSize = 5;
    Dictionary<GameObject, Queue<GameObject>> poolDict = new();

    [SerializeField] GameObject ratPrefab;
    [SerializeField] GameObject batPrefab;
    [SerializeField] GameObject undead1Prefab;
    [SerializeField] GameObject undead2Prefab;
    [SerializeField] GameObject undead3Prefab;
    [SerializeField] GameObject bonePrefab;
    [SerializeField] GameObject golemPrefab;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        InitializeNewPool(ratPrefab);
        InitializeNewPool(batPrefab);
        InitializeNewPool(undead1Prefab);
        InitializeNewPool(undead2Prefab);
        InitializeNewPool(undead3Prefab);
        InitializeNewPool(bonePrefab);
        InitializeNewPool(golemPrefab);
    }

    private void InitializeNewPool(GameObject prefab)
    {
        poolDict[prefab] = new Queue<GameObject>();

        for (int i = 0; i < poolSize; i++)
            CreateNewPool(prefab);
    }

    private void CreateNewPool(GameObject prefab)
    {
        GameObject obj = Instantiate(prefab);
        if (obj.GetComponent<PooledObject>() == null)
            obj.AddComponent<PooledObject>().SetPrefab(prefab);
        obj.SetActive(false);

        poolDict[prefab].Enqueue(obj);
    }

    public GameObject GetObject(GameObject prefab)
    {
        if (!poolDict.ContainsKey(prefab))
            InitializeNewPool(prefab);

        if (poolDict[prefab].Count == 0)
            CreateNewPool(prefab);

        GameObject objectToGet = poolDict[prefab].Dequeue();

        objectToGet.SetActive(true);
        objectToGet.transform.parent = null;
        return objectToGet;
    }

    #region Return Pool
    private void ReturnPool(GameObject objectToReturn)
    {
        GameObject originalPool = objectToReturn.GetComponent<PooledObject>().prefab;


        if (!poolDict.ContainsKey(originalPool))
            InitializeNewPool(originalPool);

        objectToReturn.SetActive(false);
        objectToReturn.transform.parent = transform;

        poolDict[originalPool].Enqueue(objectToReturn);
    }

    public void DelayReturnToPool(GameObject objectToReturn, float delay = 0.01f)
    {
        //Debug.Log("Returning to pool: " + objectToReturn);

        StartCoroutine(DelayReturn(delay, objectToReturn));
    }

    IEnumerator DelayReturn(float delay, GameObject objectToReturn)
    {
        yield return new WaitForSeconds(delay);

        ReturnPool(objectToReturn);
    }
    #endregion
}