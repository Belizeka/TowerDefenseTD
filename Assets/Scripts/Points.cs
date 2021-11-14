using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Points : MonoBehaviour
{
	public Text PointsText;

	// Update is called once per frame
	void Update()
	{
		PointsText.text = "POINTS: " + Player.Points.ToString();
	}
}
