using UnityEngine;

public class AttackAMS : StateMachineBehaviour
{
    [Range(0f, 1f)] public float openAt = 0.15f;
    [Range(0f, 1f)] public float closeAt = 0.45f;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<Attack>();
        attack.Close();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        var attack = animator.GetComponent<Attack>();

        float t = stateInfo.normalizedTime % 1f;

        if (t >= openAt && t < closeAt) attack.Open();
        else attack.Close();
    }
}
