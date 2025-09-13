using UnityEngine;

public class PlayerGhostDestroy : MonoBehaviour
{
    [SerializeField] private float lifeTime = 1f;
    private void Update()
    {
        Destroy(gameObject, lifeTime);
    }
}
