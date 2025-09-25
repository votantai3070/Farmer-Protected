using UnityEngine;

public class ExpController : Item
{
    private Transform player;

    protected override void Awake()
    {
        base.Awake();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        AttactedByPlayer();
    }

    void AttactedByPlayer()
    {
        float distance = Vector2.Distance(transform.position, player.position);
        if (MagnetController.Instance.isMagnetActive)
            transform.position = Vector2.Lerp(transform.position, player.position, 30f * Time.deltaTime);
        if (distance < 2.5f)
            transform.position = Vector2.Lerp(transform.position, player.position, 20f * Time.deltaTime);
    }
}