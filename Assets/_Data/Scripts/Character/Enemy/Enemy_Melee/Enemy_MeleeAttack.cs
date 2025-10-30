using UnityEngine;

public class Enemy_MeleeAttack : MonoBehaviour
{
    public WeaponData enemyWeaponData;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("collision: " + collision);

        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                int randomValue = Random.Range(enemyWeaponData.firstDamage, enemyWeaponData.lastDamage + 1);

                damagable.TakeDamage(randomValue);
            }
        }
    }
}
