using UnityEngine;

public class ObjectDestroy : MonoBehaviour
{
    [SerializeField] float lifetime = 5f;

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
        ObjectPool.instance.DelayReturnToPool(gameObject);
    }
}
