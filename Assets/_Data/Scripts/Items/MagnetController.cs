using System.Collections;
using UnityEngine;

public class MagnetController : Item
{
    public static MagnetController Instance;

    [HideInInspector] public bool isMagnetActive = false;
    protected override void Awake()
    {
        base.Awake();
        Instance = this;
    }
    public IEnumerator MagnetEffect()
    {
        isMagnetActive = true;
        yield return new WaitForSeconds(itemData.timeLimit);
        isMagnetActive = false;
    }
}
