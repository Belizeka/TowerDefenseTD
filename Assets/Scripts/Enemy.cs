using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
	public float speed;
	float health;
	public float startHealth = 100;
	public Image healthBar;
	public int Worth = 50;
	public int Points = 150;
	public int TypeEnemy = 1;

	void Start()
	{
		health = startHealth;
	}


	public void TakeDamage(float amount)
	{
		health -= amount;
		healthBar.fillAmount = health / startHealth;
		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Player.Money += Worth * TypeEnemy;
		Player.Points += Points * TypeEnemy;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}



}
