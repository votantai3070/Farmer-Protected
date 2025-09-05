using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [Header("Slime Attack Setting")]
    public CapsuleCollider2D capsuleCollider;
    private Weapon weapon;

    private void Awake()
    {
        capsuleCollider.enabled = false;
        weapon = GameObject.FindWithTag("SlimeWeapon").GetComponent<Weapon>();
    }

    public void HandleSlimeAttack()
    {
        capsuleCollider.enabled = true;
    }

    public void HideCollider()
    {
        capsuleCollider.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (weapon == null) Debug.LogWarning("Don't find Close Weapon Movement");

            if (collision.TryGetComponent<IDamagable>(out var damagable))
            {
                Debug.Log("damagable: " + damagable);
                weapon.Attack(damagable);
            }
        }
    }
}