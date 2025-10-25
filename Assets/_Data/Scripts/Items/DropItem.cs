using UnityEditor.U2D.Animation;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private ObjectPool bulletItemPool;
    [SerializeField] private ObjectPool speedItemPool;
    [SerializeField] private ObjectPool exp1Pool;
    [SerializeField] private ObjectPool exp2Pool;
    [SerializeField] private ObjectPool exp3Pool;
    [SerializeField] private ObjectPool potionPool;

    private void Drop(ObjectPool pool, Vector3 pos, Quaternion rot)
    {
        if (pool == null) return;

        //GameObject obj = pool.GetObject();
        //obj.transform.SetPositionAndRotation(pos, rot);
    }

    public void DropExp1(Transform transform) => Drop(exp1Pool, transform.position, transform.rotation);
    public void DropExp2(Transform transform) => Drop(exp2Pool, transform.position, transform.rotation);
    public void DropExp3(Transform transform) => Drop(exp3Pool, transform.position, transform.rotation);
    void DropPotion(Transform transform) => Drop(potionPool, transform.position, transform.rotation);
    void DropSpeedItem(Transform transform) => Drop(speedItemPool, transform.position, transform.rotation);
    void DropBulletItem(Transform transform) => Drop(bulletItemPool, transform.position, transform.rotation);


    public void SetEnemyDropItem(Transform transform, CharacterData data)
    {
        bool droppedBullet = Random.value < data.dropBulletChange;
        bool droppedPotion = Random.value < data.dropPotionChange;
        bool droppedSpeed = Random.value < data.dropSpeedChange;

        if (droppedBullet)
            DropBulletItem(transform);

        else if (droppedPotion)
            DropPotion(transform);

        else if (droppedSpeed)
            DropSpeedItem(transform);
    }
}
