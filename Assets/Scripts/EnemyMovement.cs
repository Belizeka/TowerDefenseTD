using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
	private Transform target;
	private int wavepointIndex = 0;
	private Enemy enemy;

	void Start()
	{
		enemy = GetComponent<Enemy>();
		target = Waypoints.points[0];
	}

	void Update()
	{
		Vector3 dir = target.position - transform.position;
		transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

		if (Vector3.Distance(transform.position, target.position) <= (enemy.speed / 100))
		{
			GetNextWaypoint();
		}
	}


	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1)
		{
			EndPath();
			return;
		}

		wavepointIndex++;
		target = Waypoints.points[wavepointIndex];
	}

	void EndPath()
	{
		Player.Lives -= enemy.TypeEnemy;
		WaveSpawner.EnemiesAlive--;
		Destroy(gameObject);
	}
}
