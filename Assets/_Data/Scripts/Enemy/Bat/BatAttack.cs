using System.Collections;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    [Header("Bat Enemy Setting")]
    public Weapon weapon;
    public GameObject stonePrefab;
    public Transform stoneSpawnPoint;
    private StonePool stonePool;
    private Transform player;
    public EnemyAnimation batAnimation;

    [HideInInspector] public bool isAttacking = false;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        stonePool = FindAnyObjectByType<StonePool>();
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
        GameObject stone = stonePool.GetStone();
        stone.transform.position = stoneSpawnPoint.position;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }
}
