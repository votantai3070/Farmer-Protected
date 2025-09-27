using UnityEngine;

public class Enemy : Character
{
    protected DropItem drop;
    Rigidbody2D rb;
    Transform player;


    protected virtual void Awake()
    {
        drop = GameObject.Find("GameManager").GetComponent<DropItem>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    //protected override void Update()
    //{
    //    base.Update();
    //    if (rb != null && player != null)
    //    {
    //        Knockback.Instance.KnockbackEffect(rb, player.position, 10f, 2f, path);
    //    }
    //}
}
