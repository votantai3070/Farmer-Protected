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
    //public ObjectPool arrowPool;
    //public ObjectPool stonePool;

    [SerializeField] private ObjectPool shovelPool;
    [SerializeField] private ObjectPool rakePool;
    [SerializeField] private ObjectPool sicklePool;

    [SerializeField] private HotBarManager hotBarManager;
    private Dictionary<string, ObjectPool> weaponPools;

    private float attackCooldown = 0.5f;

    [Header("Stamina Setting")]
    //public float bowStamina = 10;
    //public float stoneStamina = 1;
    [SerializeField] float shovelStamina = 2;

    private void Awake()
    {
        weaponPools = new Dictionary<string, ObjectPool>
        {
            { "Shovel", shovelPool },
            { "Rake", rakePool },
            { "Sickle", sicklePool }
        };
    }

    private void Update()
    {
        if (Time.timeScale == 0f) return;

        if (Input.GetMouseButtonDown(0)
            && !player.isAttacked
            && playerStamina.CurrentStamina > shovelStamina)
        {
            StartCoroutine(HandlePlayerShovelAttack());
        }
        //else if (Input.GetKeyDown(KeyCode.Q) &&
        //    !player.isAttacked &&
        //    playerStamina.CurrentStamina > bowStamina)
        //{
        //    StartCoroutine(HandlePlayerBowAttack());
        //}
        //else if (Input.GetKeyDown(KeyCode.E) &&
        //    !player.isAttacked &&
        //    playerStamina.CurrentStamina > stoneStamina)
        //{
        //    StartCoroutine(HandlePlayerThrowAttack());
        //}
    }

    //IEnumerator HandlePlayerSlashAttack()
    //{
    //    player.HandleAttack();
    //    rb.linearVelocity = Vector2.zero;

    //    playerAnimation.SwitchAnimationState("SLASH");
    //    playerAnimation.animator.SetBool("Walk", false);

    //    yield return new WaitForSeconds(attackCooldown);
    //    player.StopAttack();
    //}

    //IEnumerator HandlePlayerThrowAttack()
    //{
    //    player.HandleAttack();
    //    rb.linearVelocity = Vector2.zero;

    //    GetRockFromPool();

    //    playerAnimation.SwitchAnimationState("THROW");
    //    playerAnimation.animator.SetBool("Walk", false);

    //    yield return new WaitForSeconds(attackCooldown);
    //    player.StopAttack();
    //}

    //IEnumerator HandlePlayerBowAttack()
    //{
    //    player.HandleAttack();
    //    rb.linearVelocity = Vector2.zero;

    //    GetArrowFromPool();
    //    playerStamina.UseStamina(10);
    //    playerAnimation.SwitchAnimationState("BOW");
    //    playerAnimation.animator.SetBool("Walk", false);

    //    yield return new WaitForSeconds(attackCooldown);
    //    player.StopAttack();
    //}
    IEnumerator HandlePlayerShovelAttack()
    {
        GetWeaponFromPool();
        playerStamina.UseStamina(shovelStamina);

        yield return new WaitForSeconds(attackCooldown);
    }

    //private void GetArrowFromPool()
    //{
    //    if (arrowPool == null)
    //    {
    //        Debug.LogError("objectPool reference is missing!"); return;
    //    }
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector3 lookDir = (mousePos - transform.position).normalized;

    //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

    //    GameObject obj = arrowPool.Get();
    //    obj.transform.position = firePoint.position;
    //    obj.transform.rotation = Quaternion.Euler(0, 0, angle);

    //    obj.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
    //}

    //private void GetRockFromPool()
    //{
    //    if (stonePool == null)
    //    {
    //        Debug.LogError("StonePool reference is missing!"); return;
    //    }
    //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    //    Vector3 lookDir = (mousePos - transform.position).normalized;

    //    float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

    //    GameObject stone = stonePool.Get();
    //    stone.transform.position = firePoint.position;
    //    stone.transform.rotation = Quaternion.Euler(0, 0, angle);

    //    stone.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
    //}

    private void GetWeaponFromPool()
    {
        if (shovelPool == null)
        {
            Debug.LogError("Pool reference is missing!"); return;
        }
        Vector3 mousePos = inputManager.HandleMovementFollowMouse();

        Vector3 lookDir = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        UpdateWeapon(angle);
    }

    void UpdateWeapon(float angle)
    {
        string weaponName = hotBarManager.currentWeaponData.weaponName;

        if (weaponPools.TryGetValue(weaponName, out ObjectPool pool))
        {
            GameObject weapon = pool.Get();
            weapon.transform.SetPositionAndRotation(firePoint.position, Quaternion.Euler(0, 0, angle));
            weapon.GetComponent<RangeWeaponMovement>().HandleRangeWeaponMovement(false);
        }
        else
        {
            Debug.LogWarning($"No pool found for weapon: {weaponName}");
        }
    }
}
