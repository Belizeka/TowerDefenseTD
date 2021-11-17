using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public static bool GameIsOver;

	public GameObject gameOverUI;
	public GameObject completeLevelUI;

	void Start()
	{
		GameIsOver = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (GameIsOver)
			return;

		if (Player.Lives <= 0)
		{
			EndGame();
		}

		if (Player.Points >= 2000)
		{
			WinLevel();
		}

		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.tag == "Tower" && hit.collider.gameObject.GetComponent<TurretControl>().Control == false)
				{
                   hit.collider.gameObject.GetComponent<TurretControl>().Control = true;
					Debug.Log("Control = On");
				}

				else if (hit.transform.tag == "Tower" && hit.collider.gameObject.GetComponent<TurretControl>().Control == true)
				{
					hit.collider.gameObject.GetComponent<TurretControl>().Control = false;
					Debug.Log("Control = Off");
				}
			}
		}


	}

	void EndGame()
	{
		GameIsOver = true;
		gameOverUI.SetActive(true);
	}

	public void WinLevel()
	{
		GameIsOver = true;
		completeLevelUI.SetActive(true);
	}
}
