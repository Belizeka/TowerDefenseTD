using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	private Transform target;

    public float speed = 70f;

	public int damage = 50;

	public float explosionRadius = 0f;

	public void Seek(Transform _target)
	{
		target = _target;
	}


    // Update is called once per frame
    void Update()
    {

        if (target == null)
        {
            gameObject.SetActive(false);
            //Destroy(gameObject);
            return;
        }
 
            Vector3 dir = target.position - transform.position;
            float distanceThisFrame = speed * Time.deltaTime;

            if (dir.magnitude <= distanceThisFrame)
            {
                HitTarget();
                return;
            }

            transform.Translate(dir.normalized * distanceThisFrame, Space.World);
            transform.LookAt(target);

    }


    void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }
        gameObject.SetActive(false);
        // Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                Damage(collider.transform);
            }
        }
    }

    void Damage(Transform enemy)
    {
        Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
