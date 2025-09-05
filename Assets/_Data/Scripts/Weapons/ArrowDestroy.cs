using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public float lifetime = 5f;
    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = GameObject.Find("ArrowPool").GetComponent<ObjectPool>();
    }

    private void OnEnable()
    {
        Invoke("DestroyArrow", lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke("DestroyArrow");
    }

    private void DestroyArrow()
    {
        if (objectPool != null)
        {
            objectPool.ReturnPool(gameObject);
        }
    }
}
