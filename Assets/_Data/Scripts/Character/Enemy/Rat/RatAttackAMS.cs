using UnityEngine;

public class RatAttackAMS : StateMachineBehaviour
{
    [Range(0f, 1f)] public float openAt;
    [Range(0f, 1f)] public float closeAt;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<RatAttackCollider>();

        attack.Close();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<RatAttackCollider>();

        float t = stateInfo.normalizedTime % 1f;

        if (t >= openAt && t < closeAt) attack.Open();
        else attack.Close();
    }
}
