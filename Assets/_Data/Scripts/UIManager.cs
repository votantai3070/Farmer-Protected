using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI ammoText;


    private void Awake()
    {
        Instance = this;
    }


    private void Start()
    {
        ammoText.enabled = false;
    }
}
