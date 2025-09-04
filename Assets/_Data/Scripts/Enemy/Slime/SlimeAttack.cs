using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    [Header("Slime Attack Setting")]
    public CapsuleCollider2D capsuleCollider;

    public void HandleSlimeAttack()
    {
        capsuleCollider.enabled = true;
    }

    public void HideCollider()
    {
        capsuleCollider.enabled = false;
    }
}