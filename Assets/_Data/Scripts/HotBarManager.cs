using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotBarManager : MonoBehaviour
{
    [Header("Hot Bar Manager")]
    [SerializeField] private InventorySlot[] hotbarSlots;

    [HideInInspector] public WeaponData currentWeaponData;
    [SerializeField] Bullet bullet;

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
                if (!bullet.ammoMap.ContainsKey(weapon.weaponName))
                    bullet.SetWeaponData(weapon);
                else
                    bullet.SetWeaponFromDictionary(weapon);

                currentWeaponData = weapon;

                if (weapon.weaponType == WeaponData.WeaponType.Gun)
                {
                    var (current, reserve, magazineSize) = bullet.ammoMap[weapon.weaponName];
                    UIManager.Instance.ammoText.enabled = true;
                    UIManager.Instance.ammoText.text =
                        $"{current}/{reserve}";
                }
                else
                {
                    UIManager.Instance.ammoText.enabled = false;
                }
            }
            else
            {
                Debug.Log("Slot " + index + " is empty!");
            }
        }
    }
}
