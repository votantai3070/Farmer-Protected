using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public TextMeshProUGUI ammoText;

    [SerializeField] GameObject defeatEnemy;
    int currentAmount = 0;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }


    private void Start()
    {
        ammoText.enabled = false;
        defeatEnemy.transform.GetChild(0).GetComponent<Image>().sprite = GameManager.Instance.UIAtlas.GetSprite("Icon 0");
    }

    public void UpdateDefeatEnemy(int amount)
    {
        currentAmount += amount;
        var text = defeatEnemy.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        text.text = currentAmount.ToString();
    }
}
