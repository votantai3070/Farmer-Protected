using UnityEngine;
using UnityEngine.EventSystems;

public class Upgrade : MonoBehaviour, IPointerClickHandler
{
    private GameObject upgradePanel;
    public WeaponData weaponData;
    private HotBarManager hotBarManager;

    private void Start()
    {
        upgradePanel = GameObject.Find("ChooseWeaponPanel");
        hotBarManager = GameObject.Find("HotBarManager").GetComponent<HotBarManager>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        upgradePanel.SetActive(false);
        UpgradeWeapon();
    }

    private void UpgradeWeapon()
    {
        if (weaponData != null)
        {
            for (int i = 0; i < hotBarManager.hotbarSlots.Length; i++)
            {
                if (hotBarManager.hotbarSlots[i].transform.childCount > 0)
                {
                    if (hotBarManager.hotbarSlots[i].transform.GetChild(0).GetComponent<DraggableItem>().weaponData.weaponName == weaponData.weaponName)
                    {
                        DraggableItem newItem = hotBarManager.hotbarSlots[i].transform.GetChild(0).GetComponent<DraggableItem>();
                        newItem.SetItem(weaponData);
                        return;
                    }
                }
            }
        }
    }

    public void SetWeaponData(WeaponData weapon)
    {
        weaponData = weapon;
    }
}