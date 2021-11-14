using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lives : MonoBehaviour
{
	public Text livesText;

	// Update is called once per frame
	void Update()
	{
		livesText.text = "LIVES: " +Player.Lives.ToString();
	}
}
