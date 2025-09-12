using UnityEngine;

public class SlimeAttackCollider : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider;
    private void Awake()
    {
        capsuleCollider.enabled = false;
    }

    public void Open()
    {
        capsuleCollider.enabled = true;
    }

    public void Close()
    {
        capsuleCollider.enabled = false;
    }
}
