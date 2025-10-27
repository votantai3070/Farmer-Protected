using UnityEngine;

public class StoneDestroy : MonoBehaviour
{
    public float lifetime = 5f;

    private void OnEnable()
    {
        Invoke("DestroyStone", lifetime);
    }

    private void OnDisable()
    {
        CancelInvoke("DestroyStone");
    }

    private void DestroyStone()
    {
        ObjectPool.instance.DelayReturnToPool(gameObject);
    }
}
