using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI ammoText;

    private void Awake()
    {
        if (Instance != null) Destroy(Instance);
        Instance = this;
    }


    private void Start()
    {
        ammoText.enabled = false;
    }
}
