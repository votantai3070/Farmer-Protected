using UnityEngine;

public class RatAttack : Weapon
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamagable>(out IDamagable damagable))
                Attack(damagable);
        }
    }
}
