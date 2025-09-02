using System.Collections;
using UnityEngine;

public class BatAttack : MonoBehaviour
{
    public Weapon weapon;
    public GameObject stonePrefab;
    public Transform stoneSpawnPoint;
    public StonePool stonePool;
    public Transform player;
    public BatAnimation batAnimation;

    public bool isAttacking = false;

    public IEnumerator HandleBatThrowAttack()
    {
        isAttacking = true;
        GetStoneFromPool();
        if (batAnimation != null && isAttacking)
            batAnimation.SwitchAnimation("ATTACK");
        yield return new WaitForSeconds(1f);
        if (batAnimation != null && !isAttacking)
            batAnimation.SwitchAnimation("FLY");
        isAttacking = false;
    }

    void GetStoneFromPool()
    {
        GameObject stone = stonePool.GetStone();
        stone.transform.position = stoneSpawnPoint.position;

        stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(true);
    }
}
