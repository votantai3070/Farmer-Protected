using UnityEngine;

public class Bullet : MonoBehaviour
{


    public void Shot(int bulletToUse, ref int currentAmmo, int reserveAmmo)
    {

        currentAmmo -= bulletToUse;

        currentAmmo = Mathf.Max(0, currentAmmo);

        UIManager.Instance.ammoText.text =
                $"{currentAmmo}"
                + "/"
                + $"{reserveAmmo}";
    }
}
