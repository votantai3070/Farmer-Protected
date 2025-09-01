using UnityEngine;

public class RangeWeaponMovement : Weapon
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleRangeWeaponMovement()
    {
        rb.linearVelocity = transform.right * weaponData.speed;
    }
}
