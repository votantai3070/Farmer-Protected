using UnityEngine;

public class Player : Character
{
    [HideInInspector] public bool isAttacked = false;

    private void Update()
    {
        Debug.Log(isAttacked);
    }

    public void HandleAttack()
    {
        isAttacked = true;
    }

    public void StopAttack()
    {
        isAttacked = false;
    }
}
