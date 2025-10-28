using System.Collections;
using UnityEngine;

public enum WeaponType
{
    Enemy_Attack,
    Rifle,
    Pistol,
    Shotgun,
    Throw
}

public class Weapon
{
    #region Weapon data
    public WeaponType type;
    public WeaponData weaponData;
    public int firstDamage;
    public int lastDamage;
    public float range;
    public float bulletSpeed;
    public float criticalChange;
    public float criticalDamage;
    public float stamina;
    public int magazineSize;
    public int bulletShotSize;
    public float fireRate;
    public float baseSpreadAngle;
    public int currentAmmo;
    public int reserveAmmo;
    public float attackDelayTime;
    public float reloadTime;
    public bool isAutomatic;

    private float lastShotTime = -10f;
    private float maximumSpread = 3;
    private float currentSpreadAngle;
    private float lastSpreadAngleTime;
    private float spreadIncreaseRate = .15f;
    private float spreadCooldown;
    #endregion

    public Weapon(WeaponData data)
    {
        if (data == null) return;

        this.type = data.weaponType;
        this.weaponData = data;
        this.firstDamage = data.firstDamage;
        this.lastDamage = data.lastDamage;
        this.range = data.range;
        this.bulletSpeed = data.bulletSpeed;
        this.criticalChange = data.criticalChange;
        this.criticalDamage = data.criticalDamage;
        this.stamina = data.stamina;
        this.magazineSize = data.magazineSize;
        this.bulletShotSize = data.bulletShotSize;
        this.fireRate = data.fireRate;
        this.baseSpreadAngle = data.baseSpreadAngle;
        this.currentAmmo = data.currentAmmo;
        this.reserveAmmo = data.reserveAmmo;
        this.attackDelayTime = data.attackDelayTime;
        this.reloadTime = data.reloadTime;
        this.isAutomatic = data.isAutomatic;
    }

    #region Spread
    public Vector3 ApplySpread(Vector3 orginalDirection)
    {
        UpdateSpread();

        float randomizeValue = Random.Range(-currentSpreadAngle, currentSpreadAngle);
        Quaternion spreadRot = Quaternion.Euler(0, 0, randomizeValue);

        return spreadRot * orginalDirection;
    }

    private void UpdateSpread()
    {
        if (Time.time > lastSpreadAngleTime + spreadCooldown)
        {
            currentSpreadAngle = baseSpreadAngle;
        }
        else
            IncreasedSpread();

        lastSpreadAngleTime = Time.time;
    }

    private void IncreasedSpread()
    {
        currentSpreadAngle = Mathf.Clamp(currentSpreadAngle + spreadIncreaseRate, baseSpreadAngle, maximumSpread);
    }
    #endregion

    //#region Reloading
    //public IEnumerator WaitForReload(int currentAmmo, int reserveAmmo, int magazineSize)
    //{
    //    yield return new WaitForSeconds(reloadTime);
    //    Reloading(currentAmmo, reserveAmmo, magazineSize);
    //}

    //private void Reloading(int currentAmmo, int reserveAmmo, int magazineSize)
    //{
    //    if (currentAmmo == magazineSize) return;
    //    if (reserveAmmo <= 0) return;

    //    int needed = magazineSize - currentAmmo;
    //    int bulletToLoad = Mathf.Min(needed, reserveAmmo);
    //    currentAmmo += bulletToLoad;
    //    reserveAmmo -= bulletToLoad;
    //}
    //#endregion

    #region Shooting

    public void Shooting(float angle, GameObject currentBulletPrefab, Transform firePoint, Weapon weapon, int currentAmmo)
    {
        if ((currentAmmo > 0 && type != WeaponType.Throw) || type == WeaponType.Throw)
            for (int i = 0; i < bulletShotSize; i++)
            {
                float shotgunBulletAngle = Random.Range(angle - currentSpreadAngle, angle + currentSpreadAngle);
                GameObject newBullet = ObjectPool.instance.GetObject(currentBulletPrefab);
                newBullet.transform.SetPositionAndRotation(firePoint.position, Quaternion.Euler(0, 0, shotgunBulletAngle - 90f));
                newBullet.GetComponent<BulletMovement>().HandleBulletMovement(false, weapon);
            }
    }

    public bool CanShoot() => ReadyToShoot() && IsThrowWapon();

    private bool ReadyToShoot()
    {
        if (Time.time > lastShotTime + 1 / fireRate)
        {
            lastShotTime = Time.time;
            return true;
        }
        return false;
    }

    private bool IsThrowWapon()
    {
        if (type == WeaponType.Throw) return true;


        if (type != WeaponType.Throw && currentAmmo > 0) return true;

        return false;
    }

    public void UpdateCurrentAmmo(int currentAmmo)
    {
        Debug.Log("Current ammo: " + currentAmmo);
        this.currentAmmo = currentAmmo;
    }
    #endregion

    public void UpdateAmmo(int reserveAmmo, int magazineSize)
    {
        this.reserveAmmo = reserveAmmo;
        this.magazineSize = magazineSize;
    }
}
