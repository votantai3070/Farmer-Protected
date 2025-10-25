using UnityEngine;

public class StoneDestroy : MonoBehaviour
{
    private ObjectPool stonePool;

    public float lifetime = 5f;

    private void Start()
    {
        stonePool = GameObject.Find("StonePool").GetComponent<ObjectPool>();
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
            //stonePool.ReturnPool(gameObject);
        }
    }
}
