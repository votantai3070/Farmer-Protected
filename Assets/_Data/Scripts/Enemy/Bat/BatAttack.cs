using System.Collections;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    [Header("Bat Enemy Setting")]
    public Weapon weapon;
    public GameObject stonePrefab;
    public Transform stoneSpawnPoint;
    private ObjectPool stonePool;
    private Transform player;
    public EnemyAnimation batAnimation;

    [HideInInspector] public bool isAttacking = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stonePool = GameObject.Find("StonePool").GetComponent<ObjectPool>();
    }

    public IEnumerator HandleBatThrowAttack()
    {
        isAttacking = true;
        GetStoneFromPool();
        if (batAnimation != null && isAttacking)
            batAnimation.SwitchBatAnimation("ATTACK");
        yield return new WaitForSeconds(1f);
        if (batAnimation != null && !isAttacking)
            batAnimation.SwitchBatAnimation("FLY");
        isAttacking = false;
    }

    void GetStoneFromPool()
    {
        GameObject stone = stonePool.Get();
        stone.transform.position = stoneSpawnPoint.position;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }
}
