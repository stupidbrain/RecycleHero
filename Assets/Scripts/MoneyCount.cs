using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoneyCount : MonoBehaviour {

	static Text moneyText;
	public static int money;
	public int startCapital=1000;

	void Start () {
		moneyText = GetComponent<Text> ();
		money = startCapital;
		UpdateMoney (0);
	}
	
	public static void UpdateMoney (int amount) {
		money += amount;
        moneyText.text = money.ToString("000,000");
    }
}


