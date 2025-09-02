using UnityEngine;

public class StoneDestroy : MonoBehaviour
{
    private StonePool stonePool;

    public float lifetime = 5f;

    private void Start()
    {
        stonePool = FindAnyObjectByType<StonePool>();
    }

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
        if (stonePool != null)
        {
            stonePool.ReturnRock(gameObject);
        }
    }
}
