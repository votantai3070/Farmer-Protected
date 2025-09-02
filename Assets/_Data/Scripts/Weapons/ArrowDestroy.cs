using UnityEngine;

public class ArrowDestroy : MonoBehaviour
{
    public float lifetime = 5f;
    private ArrowPool arrowPool;

    private void Start()
    {
        arrowPool = FindAnyObjectByType<ArrowPool>();
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
        if (arrowPool != null)
        {
            arrowPool.ReturnArrow(gameObject);
        }
    }
}
