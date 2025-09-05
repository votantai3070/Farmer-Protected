using UnityEngine;

public class Attack : MonoBehaviour
{
    public CapsuleCollider2D capsuleCollider;
    public void Open()
    {
        capsuleCollider.enabled = true;
    }

    public void Close()
    {
        capsuleCollider.enabled = false;
    }
}
