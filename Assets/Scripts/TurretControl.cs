using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretControl : MonoBehaviour
{

	private Transform target;
	private Enemy targetEnemy;

	public float range = 5f;

	public GameObject bulletPrefab;
	public float fireRate = 1f;
	private float fireCountdown = 0f;

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 300f;

	public Transform firePoint;

	public bool Control = false;

	Camera _camera = null;

	Vector3 dir;

	// Start is called before the first frame update
	void Start()
    {
		_camera = Camera.main;
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}

	void UpdateTarget()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			targetEnemy = nearestEnemy.GetComponent<Enemy>();
		}
		else
		{
			target = null;
		}

	}

	// Update is called once per frame
	void Update()
	{
        if (target == null)
        {
            return;
        }
        if (!Control)
		{
			LockOnTarget();
			if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}

			fireCountdown -= Time.deltaTime;
		}
		else if (Control)
		{
			Rotateturret();
            if(Input.GetMouseButtonDown(1))
			{
				UpdateTarget();
				Shoot();
				Debug.Log("Shoot on enemy");
			}
		}
		
	}

	void Rotateturret()
	{
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
		Vector3 dir = ray.direction;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, rotation.z);

    }


	void LockOnTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion lookRotation = Quaternion.LookRotation(dir);
		Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
		partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
	}

	void Shoot()
	{
		GameObject bulletGO = ObjectPool.SharedInstance.GetPooledObject();
		if(bulletGO != null)
		{
			bulletGO.transform.position = firePoint.position;
			bulletGO.transform.rotation = firePoint.rotation;
			bulletGO.SetActive(true);
			Ammo bullet = bulletGO.GetComponent<Ammo>();
			if (bullet != null)
				bullet.Seek(target);
		}

		//GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		//Ammo bullet = bulletGO.GetComponent<Ammo>();
		//if (bullet != null)
		//	bullet.Seek(target);
	}



	void OnDrawGizmosSelected()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
