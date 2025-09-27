using UnityEngine;

public class UndeadAttack : Weapon
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                Attack(damagable);
            }
        }
    }
}
