using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject inventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenInventoryBtn();
        }
    }

    public void CloseInventoryBtn()
    {
        inventory.SetActive(false);
        Time.timeScale = 1f;

        Input.ResetInputAxes();
    }

    void OpenInventoryBtn()
    {
        inventory.SetActive(true);
        Time.timeScale = 0f;
    }
}
