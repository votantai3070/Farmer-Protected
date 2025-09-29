using UnityEngine;

public class ChooseUpgradeCharacter : MonoBehaviour
{
    public static ChooseUpgradeCharacter Instance;
    [SerializeField] private GameObject upgradePanel;
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private AvailableUpgrade availableUpgrade;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void OpenChooseCharacterPanel()
    {
        upgradePanel.SetActive(true);
        menuPanel.SetActive(false);
        availableUpgrade.SetPlayerAvailable();

    }
    public void CloseChooseCharacterPanel()
    {
        upgradePanel.SetActive(false);
        menuPanel.SetActive(true);
    }
}
