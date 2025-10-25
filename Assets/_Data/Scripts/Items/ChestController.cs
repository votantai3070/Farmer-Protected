using UnityEngine;
using DG.Tweening;

public class ChestController : MonoBehaviour
{
    [Header("Chest Setting")]
    private SpriteRenderer sr;
    private Sprite openedChestSprite;
    private Sprite closedChestSprite;
    private ObjectPool potionPool;
    private ObjectPool bulletItemPool;

    public bool isOpened = false;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        potionPool = GameObject.Find("PotionPool").GetComponent<ObjectPool>();
        bulletItemPool = GameObject.Find("BulletItemPool").GetComponent<ObjectPool>();
    }

    private void Start()
    {
        closedChestSprite = GameManager.Instance.UIAtlas.GetSprite("Box 0");
        openedChestSprite = GameManager.Instance.UIAtlas.GetSprite("Box 1");
        sr.sprite = closedChestSprite;
    }

    public void OpenChest()
    {
        isOpened = true;

        sr.sprite = openedChestSprite;

        int random = Random.Range(0, 2);

        if (random == 0)
        {
            //var potion = potionPool.GetObject();
            //potion.transform.SetPositionAndRotation(transform.position + Vector3.up, transform.rotation);
            ////potion.transform.DOMove(transform.position + Vector3.up, 0.5f);
            //potion.SetActive(true);
        }
        else
        {
            //var bulletItem = bulletItemPool.GetObject();
            //bulletItem.transform.SetPositionAndRotation(transform.position + Vector3.up, transform.rotation);
            ////bulletItem.transform.DOMove(transform.position + Vector3.up, 0.5f);
            //bulletItem.SetActive(true);
        }

        transform.tag = "Untagged";
    }

}
