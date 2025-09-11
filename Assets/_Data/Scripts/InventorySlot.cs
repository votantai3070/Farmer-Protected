using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DraggableItem draggableItem = dropped.GetComponent<DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }

    public WeaponData GetWeaponData()
    {
        if (transform.childCount > 0)
        {
            DraggableItem draggableItem = transform.GetChild(0).GetComponent<DraggableItem>();
            return draggableItem.weaponData;
        }
        return null;
    }
}
