using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildButtons2 : MonoBehaviour {

	public int price=500;
	Button btn;

	void Start () {
		btn = GetComponent<Button>();
	}

	void Update () {

		if (MoneyCount2.money >= price)
			btn.interactable = true;
		else
			btn.interactable = false;
	}
}


