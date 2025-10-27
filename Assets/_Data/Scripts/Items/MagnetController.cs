using System.Collections;
using UnityEngine;

public class MagnetController : Item
{
    public static MagnetController instance;

    private bool isMagnetActive = false;
    protected override void Awake()
    {
        base.Awake();

        instance = this;

    }

    public bool IsMagnetActive() => isMagnetActive;

    public IEnumerator MagnetEffect()
    {
        isMagnetActive = true;
        yield return new WaitForSeconds(itemData.timeLimit);
        isMagnetActive = false;
    }
}
