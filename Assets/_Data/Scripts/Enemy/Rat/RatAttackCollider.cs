using UnityEngine;

public class RatAttackCollider : Weapon
{
    [Header("Rat Attack Collider Setting")]
    public CapsuleCollider2D capsuleCollider;

    public void Open()
    {
        if (capsuleCollider != null)
            capsuleCollider.enabled = true;
    }

    public void Close()
    {
        if (capsuleCollider != null)
            capsuleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (capsuleCollider != null)
        {
            if (collision.CompareTag("Player"))
            {
                if (collision.TryGetComponent<IDamagable>(out var damagable))
                    Attack(damagable);
            }
        }
    }
}
