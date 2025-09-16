using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player Attack Setting")]
    public PlayerController player;
    public PlayerStamina playerStamina;
    public PlayerAnimation playerAnimation;
    public InputManager inputManager;
    public Rigidbody2D rb;
    public Transform firePoint;
    public Bullet bullet;
    bool isReloading;

    [Header("Pool Setting")]
    [SerializeField] private ObjectPool shovelPool;
    [SerializeField] private ObjectPool rakePool;
    [SerializeField] private ObjectPool sicklePool;
    [SerializeField] private ObjectPool rifleBulletPool;

    [SerializeField] private HotBarManager hotBarManager;
    private Dictionary<string, ObjectPool> weaponPools;


    private void Awake()
    {
        weaponPools = new Dictionary<string, ObjectPool>
        {
            { "Shovel", shovelPool },
            { "Rake", rakePool },
            { "Sickle", sicklePool },
            { "Rifle Gun", rifleBulletPool }
        };
    }
    private void Update()
    {
        WeaponData weaponData = hotBarManager.currentWeaponData;

        if (Time.timeScale == 0f) return;

        if (Input.GetMouseButtonDown(0)
            && !player.isAttacked
            && playerStamina.CurrentStamina > weaponData.stamina
            && weaponData.isAutomatic == false)
        {
            StartCoroutine(HandlePlayerAttack(weaponData));
        }
        else if (Input.GetMouseButton(0)
            && !player.isAttacked
            && weaponData.isAutomatic == true
            && weaponData.currentAmmo > 0
            && bullet.currentAmmo > 0)
        {
            StartCoroutine(HandlePlayerAttack(weaponData));
        }
        else if (Input.GetKeyDown(KeyCode.R)
            && !isReloading
            && weaponData.isAutomatic == true)
        {
            StartCoroutine(HandleReloadAmmo(weaponData));
        }
    }

    IEnumerator HandlePlayerAttack(WeaponData weaponData)
    {
        player.HandleAttack();

        if (weaponData.weaponType == WeaponData.WeaponType.Gun)
            bullet.Shot(1);

        else
            playerStamina.UseStamina(weaponData.stamina);

        GetWeaponFromPool(weaponData);

        yield return new WaitForSeconds(weaponData.attackDelayTime);
        player.StopAttack();
    }

    IEnumerator HandleReloadAmmo(WeaponData weapon)
    {
        isReloading = true;

        bullet.Reload();
        yield return new WaitForSeconds(weapon.reloadTime);

        isReloading = false;
    }

    private void GetWeaponFromPool(WeaponData weaponData)
    {
        if (shovelPool == null)
        {
            Debug.LogError("Pool reference is missing!"); return;
        }
        Vector3 mousePos = inputManager.HandleMovementFollowMouse();

        Vector3 lookDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        UpdateWeapon(angle, weaponData);
    }

    void UpdateWeapon(float angle, WeaponData weaponData)
    {
        string weaponName = weaponData.weaponName;

        if (weaponPools.TryGetValue(weaponName, out ObjectPool pool))
        {
            GameObject weapon = pool.Get();
            weapon.transform.SetPositionAndRotation(firePoint.position, Quaternion.Euler(0, 0, angle - 90f));
            weapon.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
        }
        else
        {
            Debug.LogWarning($"No pool found for weapon: {weaponName}");
        }
    }
}
