using UnityEngine;
using TMPro;

public class moneyCounter : MonoBehaviour
{
    public static moneyCounter instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is createdpublic static ScoreCounter instance;
    public TMP_Text scoreText;
    public int currentMoney;
    
    void Awake()
    {
        instance = this;
    }
    
    
    void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Money");
        scoreText.text = "" + currentMoney.ToString();
    }

    public void IncreaseMoney(int v)
    {
        currentMoney += v;
        scoreText.text = "" + currentMoney.ToString();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
    public void DecreseMoney(int v)
    {
        currentMoney -= v;
        scoreText.text = "" + currentMoney.ToString();
        PlayerPrefs.SetInt("Money", currentMoney);
    }
}
