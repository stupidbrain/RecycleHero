using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class MoneyCount2 : MonoBehaviour
{

    static Text moneyText;
    public static int money;
    
    //public int startCapital = 2500;

    void Start()
    {
        moneyText = GetComponent<Text>();
        money = PlayerPrefs.GetInt("moneycount");
        
        UpdateMoney(0);
    }

    public static void UpdateMoney(int amount)
    {
        money += amount;
        moneyText.text = money.ToString("000,000");
    }
}


