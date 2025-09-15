using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DraggableItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Image image;
    public WeaponData weaponData;

    [HideInInspector] public Transform parentAfterDrag;
    private GameObject parentBeforeDrag;

    private void Start()
    {
        parentBeforeDrag = GameObject.Find("Inventory");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        parentAfterDrag = transform.parent;
        transform.SetParent(parentBeforeDrag.transform);
        transform.SetAsLastSibling();
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag);
        image.raycastTarget = true;
    }

    public void SetItem(WeaponData weapon)
    {
        weaponData = weapon;
        image.sprite = GameManager.Instance.UIAtlas.GetSprite(weapon.UISprite);
    }
}
