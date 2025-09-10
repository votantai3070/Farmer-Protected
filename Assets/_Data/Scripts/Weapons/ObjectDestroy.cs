using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 5f;
    private ObjectPool objectPool;

    [SerializeField] string poolName;

    private void Start()
    {
        objectPool = GameObject.Find($"{poolName}").GetComponent<ObjectPool>();
    }

    private void OnEnable()
    {
        Invoke(nameof(DestroyObject), lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke(nameof(DestroyObject));
    }

    private void DestroyObject()
    {
        if (objectPool != null)
        {
            objectPool.ReturnPool(gameObject);
        }
    }
}
