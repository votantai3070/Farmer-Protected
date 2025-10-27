using UnityEngine;

public class Enemy_MeleeAttack : MonoBehaviour
{
    public WeaponData enemyWeaponData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) return;

        if (collision.CompareTag("Player"))
        {
            IDamagable damagable = collision.GetComponent<IDamagable>();
            if (damagable != null)
            {
                //bool isCrit = Random.value <= enemyWeaponData.critChance;
                int randomValue = Random.Range(enemyWeaponData.firstDamage, enemyWeaponData.lastDamage + 1);

                damagable.TakeDamage(randomValue);
            }
        }
    }
}
