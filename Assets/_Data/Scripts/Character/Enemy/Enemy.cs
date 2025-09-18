using UnityEngine;

public class Enemy : Character
{
    protected DropItem drop;

    protected virtual void Awake()
    {
        drop = GameObject.Find("GameManager").GetComponent<DropItem>();
    }
}
