using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Weapon Setting")]
    public WeaponData weaponData;

    public void Attack(IDamagable target)
    {
        UseWeapon(target);
    }

    private void UseWeapon(IDamagable target)
    {
        Debug.Log($"firstDamage: {weaponData.firstDamage}, lastDamage: {weaponData.lastDamage}");
        bool isCrit = Random.value <= weaponData.criticalChange;
        int curentDamage = (int)(isCrit
            ? Random.Range(weaponData.firstDamage, weaponData.lastDamage + 1) * weaponData.criticalDamage
            : Random.Range(weaponData.firstDamage, weaponData.lastDamage + 1));

        target.TakeDamage(Mathf.FloorToInt(curentDamage), isCrit);
    }
}
