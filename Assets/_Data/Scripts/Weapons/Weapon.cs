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
        bool isCrit = Random.value <= weaponData.criticalChange;
        int curentDamage = (int)(isCrit
            ? Random.Range(weaponData.firstDamage, weaponData.lastDamage + 1) * weaponData.criticalDamage
            : Random.Range(weaponData.firstDamage, weaponData.lastDamage + 1));
        Debug.Log($"Damage: {curentDamage} - Crit: {isCrit}");
        target.TakeDamage(Mathf.FloorToInt(curentDamage), isCrit);
    }
}
