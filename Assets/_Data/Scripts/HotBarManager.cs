using System.Collections;
using UnityEngine;

public class HotBarManager : MonoBehaviour
{
    [Header("Hot Bar Manager")]
    [SerializeField] private InventorySlot[] hotbarSlots;

    [HideInInspector] public WeaponData currentWeaponData;

    private void Start()
    {
        StartCoroutine(InitHotbar());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) UseWeaponInSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseWeaponInSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseWeaponInSlot(2);
    }

    IEnumerator InitHotbar()
    {
        yield return null;
        UseWeaponInSlot(0);
    }

    public void UseWeaponInSlot(int index)
    {
        if (index >= 0 && index < hotbarSlots.Length)
        {
            WeaponData weapon = hotbarSlots[index].GetWeaponData();

            if (weapon != null)
            {
                currentWeaponData = weapon;
                if (weapon.weaponType == WeaponData.WeaponType.Gun)
                {
                    UIManager.Instance.ammoText.enabled = true;
                    UIManager.Instance.ammoText.text =
                        $"{weapon.currentAmmo}"
                        + "/"
                        + $"{weapon.reserveAmmo}";
                }
            }
            else
            {
                Debug.Log("Slot " + index + " is empty!");
            }

        }
    }
}
