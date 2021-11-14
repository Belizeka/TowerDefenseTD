using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTxt : MonoBehaviour
{
	// Start is called before the first frame update
	public Text moneyText;

	// Update is called once per frame
	void Update()
	{
		moneyText.text = Player.Money.ToString() + "$";
	}
}
