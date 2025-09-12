using UnityEngine;

public class BoneAttackCollider : MonoBehaviour
{
    public CircleCollider2D circleCollider;

    public void Open()
    {
        circleCollider.enabled = true;
    }

    public void Close()
    {
        circleCollider.enabled = false;
    }
}
