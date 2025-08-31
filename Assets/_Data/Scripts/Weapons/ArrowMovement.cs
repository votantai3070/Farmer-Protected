using UnityEngine;

public class ArrowMovement : Weapon
{
    public Rigidbody2D rb;

    public void HandleArrowMovement()
    {
        rb.linearVelocity = transform.right * weaponData.speed;
    }
}
