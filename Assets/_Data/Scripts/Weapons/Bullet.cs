using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Gun Bullet")]
    [HideInInspector] public int currentAmmo;
    [HideInInspector] public int reserveAmmo;
    [HideInInspector] int magazineSize;

    [HideInInspector] public Dictionary<string, (int current, int reserve, int magazineSize)> ammoMap = new();
    string currentWeaponName;

    public void Shot(int bulletToUse)
    {
        currentAmmo -= bulletToUse;

        currentAmmo = Mathf.Max(0, currentAmmo);

        ammoMap[currentWeaponName] = (currentAmmo, reserveAmmo, magazineSize);

        UIManager.Instance.ammoText.text = $"{currentAmmo}/{reserveAmmo}";
    }

    public void Reload()
    {
        if (currentAmmo == magazineSize) return;

        if (reserveAmmo <= 0) return;

        int needed = magazineSize - currentAmmo;

        int bulletToLoad = Mathf.Min(needed, reserveAmmo);

        currentAmmo += bulletToLoad;

        reserveAmmo -= bulletToLoad;

        ammoMap[currentWeaponName] = (currentAmmo, reserveAmmo, magazineSize);

        UIManager.Instance.ammoText.text = $"{currentAmmo}/{reserveAmmo}";
    }

    public void SetWeaponData(WeaponData weapon)
    {
        currentWeaponName = weapon.weaponName;

        ammoMap[currentWeaponName] = (weapon.currentAmmo, weapon.reserveAmmo, weapon.magazineSize);

        currentAmmo = ammoMap[currentWeaponName].current;
        reserveAmmo = ammoMap[currentWeaponName].reserve;
        magazineSize = ammoMap[currentWeaponName].magazineSize;
    }

    public void SetWeaponFromDictionary(WeaponData weapon)
    {
        currentWeaponName = weapon.weaponName;

        currentAmmo = ammoMap[currentWeaponName].current;
        reserveAmmo = ammoMap[currentWeaponName].reserve;
        magazineSize = ammoMap[currentWeaponName].magazineSize;
    }

    public void AddAmmo(ItemData bullet)
    {
        reserveAmmo = ammoMap[currentWeaponName].reserve;

        reserveAmmo += bullet.value;

        ammoMap[currentWeaponName] = (currentAmmo, reserveAmmo, magazineSize);
    }

}
