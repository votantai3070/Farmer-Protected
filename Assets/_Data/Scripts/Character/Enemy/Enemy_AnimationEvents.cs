using UnityEngine;

public class Enemy_AnimationEvents : MonoBehaviour
{
    private Enemy_Melee rat;
    private Enemy_Range bat;

    private void Start()
    {
        if (rat == null)
            rat = GetComponent<Enemy_Melee>();

        if (bat == null)
            bat = GetComponent<Enemy_Range>();
    }

    public void EnabledCollider() => rat.EnableCollider2D(true);
    public void DisabledCollider() => rat.EnableCollider2D(false);

    public void HandleEnemyRangeAttack() => bat.HandleAttack();

}
