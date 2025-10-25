using UnityEngine;

public class Enemy_AnimationEvents : MonoBehaviour
{
    private RatController rat;

    private void Start()
    {
        rat = GetComponent<RatController>();
    }

    public void EnabledCollider() => rat.EnableCollider2D(true);
    public void DisabledCollider() => rat.EnableCollider2D(false);


}
