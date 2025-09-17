using UnityEngine;

public class DropItem : MonoBehaviour
{
    public static DropItem Instance;
    [SerializeField] private ObjectPool bulletItemPool;
    [SerializeField] private ObjectPool exp1Pool;
    [SerializeField] private ObjectPool exp2Pool;
    [SerializeField] private ObjectPool exp3Pool;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance);
        Instance = this;
    }

    public void DropBulletItem(Transform transform)
    {
        GameObject bullet = bulletItemPool.Get();
        bullet.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
    public void DropExp1(Transform transform)
    {
        GameObject exp = exp1Pool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
    public void DropExp2(Transform transform)
    {
        GameObject exp = exp2Pool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
    public void DropExp3(Transform transform)
    {
        GameObject exp = exp3Pool.Get();
        exp.transform.SetPositionAndRotation(transform.position, transform.rotation);
    }
}
