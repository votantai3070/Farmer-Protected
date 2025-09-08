using UnityEngine;

public class PlayerController : Character
{
    [Header("Player Setting")]
    [HideInInspector] public bool isAttacked = false;

    public void HandleAttack()
    {
        isAttacked = true;
    }

    public void StopAttack()
    {
        isAttacked = false;
    }
}
