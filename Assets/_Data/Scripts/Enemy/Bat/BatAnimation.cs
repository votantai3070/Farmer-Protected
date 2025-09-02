using UnityEngine;

public class BatAnimation : MonoBehaviour
{
    public Animator animator;
    public void SwitchAnimation(string ani)
    {
        switch (ani)
        {
            case "ATTACK":
                animator.SetTrigger("Attack");
                break;
            case "FLY":
                animator.SetTrigger("Fly");
                break;
            default:
                break;
        }
    }
}
