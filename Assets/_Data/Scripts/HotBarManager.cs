using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HotBarManager : MonoBehaviour
{
    [Header("Hot Bar Manager")]
    public InventorySlot[] hotbarSlots;
    public List<GameObject> hotbarSlotItems = new();

    [HideInInspector] public WeaponData currentWeaponData;
    [SerializeField] Bullet bullet;

    private void Start()
    {
        StartCoroutine(InitHotbar());
    }

    private void Update()
    {
        ShowHotbarList();

        if (Input.GetKeyDown(KeyCode.Alpha1)) UseWeaponInSlot(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) UseWeaponInSlot(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) UseWeaponInSlot(2);
        //if (Input.GetKeyDown(KeyCode.Alpha4)) UseWeaponInSlot(3);
        //if (Input.GetKeyDown(KeyCode.Alpha5)) UseWeaponInSlot(4);
        //if (Input.GetKeyDown(KeyCode.Alpha6)) UseWeaponInSlot(5);

        if (currentWeaponData != null)
            UpdateWeapon();
    }

    // If the current weapon has a higher level version in the hotbar, switch to it
    void UpdateWeapon()
    {
        for (int i = 0; i < hotbarSlots.Length; i++)
        {
            WeaponData weapon = hotbarSlots[i].GetWeaponData();
            if (weapon != null && weapon.weaponName == currentWeaponData.weaponName && weapon.level > currentWeaponData.level)
            {
                UseWeaponInSlot(i);
                break;
            }
        }
    }

    // Initialize hotbar by equipping the first weapon in the first slot
    IEnumerator InitHotbar()
    {
        yield return null;
        UseWeaponInSlot(0);
    }

    // Equip weapon in the specified hotbar slot
    public void UseWeaponInSlot(int index)
    {
        if (index >= 0 && index < hotbarSlots.Length)
        {
            WeaponData weapon = hotbarSlots[index].GetWeaponData();

            if (weapon != null)
            {
                if (!bullet.ammoMap.ContainsKey((weapon.weaponName, weapon.level))
                     || bullet.ammoMap.ContainsKey((weapon.weaponName, weapon.level - 1)))
                    bullet.SetWeaponData(weapon);
                else
                    bullet.SetWeaponFromList(weapon);

                currentWeaponData = weapon;

                if (weapon.weaponType == WeaponData.WeaponType.Rifle
                    || weapon.weaponType == WeaponData.WeaponType.Pistol
                    || weapon.weaponType == WeaponData.WeaponType.Shotgun)
                {
                    //var current = bullet.weaponDatas.Find(w => w.weaponName == weapon.weaponName).currentAmmo;
                    //var reserve = bullet.weaponDatas.Find(w => w.weaponName == weapon.weaponName).reserveAmmo;

                    var (current, reserve, _) = bullet.ammoMap[(weapon.weaponName, weapon.level)];

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

    private void ShowHotbarList()
    {
        for (int i = 0; i < hotbarSlotItems.Count; i++)
        {
            WeaponData weapon = hotbarSlots[i].GetComponent<InventorySlot>().GetWeaponData();

            if (weapon != null)
            {
                hotbarSlotItems[i].transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.UIAtlas.GetSprite(weapon.UISprite);
                hotbarSlotItems[i].transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = $"{weapon.level}";
            }
            else
            {
                Debug.Log($"Hotbar Slot {i + 1}: Empty");
            }
        }
    }
}
