using UnityEngine;

public class Player : Character
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
