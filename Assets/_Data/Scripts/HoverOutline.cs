using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverOutline : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Outline outline;

    private void Awake()
    {
        outline = GetComponent<Outline>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (outline != null)
            outline.enabled = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (outline != null)
            outline.enabled = false;
    }
}
