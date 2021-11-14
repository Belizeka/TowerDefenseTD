using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	public static int Money;
	public int startMoney = 400;

	public static int Lives;
	public int startLives = 7;

	public static int Rounds;

	public static int Points;

	void Start()
	{
		Money = startMoney;
		Lives = startLives;
		Rounds = 0;
		Points = 0;
	}
}
