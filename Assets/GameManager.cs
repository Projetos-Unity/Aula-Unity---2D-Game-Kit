using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{   
    public static GameManager Instance; // Acesso global
    public int coinCount = 0;
    public TMP_Text coinText; // Arraste o texto da UI aqui

    void Awake()
    {
        // Garantir que só haja um GameManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoin(int amount)
    {
        coinCount += amount;
        UpdateUI();
    }

    void UpdateUI()
    {
        if (coinText != null)
        {
            coinText.text = coinCount.ToString();
        }
    }
}
