using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private DraggableItem currentItem;
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;

            currentItem = draggableItem;
        }
    }

    public WeaponData GetWeaponData()
    {
        return currentItem != null ? currentItem.weaponData : null;
    }
}
