using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public InputManager inputManager;
    [SerializeField] private HotBarManager hotBarManager;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        spriteRenderer.sprite = hotBarManager.currentWeaponData.sprite;
    }

    void Update()
    {
        if (Time.timeScale == 0f) return;
        GetRotateWeaponFollowMouse();

        if (hotBarManager != null)
            UpdateWeapon();
    }

    void UpdateWeapon()
    {
        WeaponData weaponData = hotBarManager.currentWeaponData;

        spriteRenderer.sprite = weaponData.sprite;
    }

    void GetRotateWeaponFollowMouse()
    {
        Vector3 mousePos = inputManager.HandleMovementFollowMouse();

        Vector3 direction = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
