using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public void Shot(int bulletToUse, ref int currentAmmo, int reserveAmmo)
    {
        currentAmmo -= bulletToUse;

        currentAmmo = Mathf.Max(0, currentAmmo);

        UIManager.Instance.ammoText.text = $"{currentAmmo}/{reserveAmmo}";
    }

    public void Reload(ref int currentAmmo, ref int reserveAmmo, int magazineSize)
    {
        int needed = magazineSize - currentAmmo;

        int bulletToLoad = Mathf.Min(needed, reserveAmmo);

        currentAmmo += bulletToLoad;

        reserveAmmo -= bulletToLoad;

        UIManager.Instance.ammoText.text = $"{currentAmmo}/{reserveAmmo}";
    }
}
