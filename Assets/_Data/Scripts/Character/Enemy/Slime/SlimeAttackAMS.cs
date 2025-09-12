using UnityEngine;

public class SlimeAttackAMS : StateMachineBehaviour
{
    [Range(0f, 1f)] public float openAt;
    [Range(0f, 1f)] public float closeAt;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<SlimeAttackCollider>();

        attack.Close();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<SlimeAttackCollider>();

        float t = stateInfo.normalizedTime % 1f;

        if (openAt <= t && t < closeAt) attack.Open();
        else attack.Close();
    }
}
