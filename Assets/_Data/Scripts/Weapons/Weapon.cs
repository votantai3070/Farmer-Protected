using UnityEngine;

public class Weapon : MonoBehaviour
{
    public WeaponData weaponData;

    public void Attack(IDamagable target)
    {
        UseWeapon(target);
    }

    private void UseWeapon(IDamagable target)
    {
        target.TakeDamage(weaponData.damage);
    }
}
