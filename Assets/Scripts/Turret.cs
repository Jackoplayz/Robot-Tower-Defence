using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform leftCannon;
    public Transform rightCannon;
    public float shootDelay;
    public float shootCountdown;
    public GameObject bulletPrefab;
    public List<Transform> enemiesInRange = new List<Transform>();
    //public float Range; do later
    //public float Reload; do later.
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AimAtTarget();
        shootCountdown += Time.deltaTime;
        if (shootCountdown >= shootDelay)
        {
            
            ShootBullet();
            shootCountdown -= shootDelay;
        }
    }

    public void AimAtTarget()
    {
        if (FindClosestTransform() == null)
        {
            return;
        }
        Vector3 closestEnemyPosition = FindClosestTransform().position;
        Vector2 direction = closestEnemyPosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
    }
    public void RemoveEnemyFromList(Transform enemyTransform)
    {
        enemiesInRange.Remove(enemyTransform);
    }

    private void ShootBullet()
    {
        GameObject leftshotBullet = Instantiate(bulletPrefab,leftCannon.position,Quaternion.identity);
        GameObject rightshotBullet = Instantiate(bulletPrefab, rightCannon.position, Quaternion.identity);
        bullet leftbulletScript = leftshotBullet.GetComponent<bullet>();
        bullet rightbulletScript = rightshotBullet.GetComponent<bullet>();
        if (leftbulletScript != null)
        {
            leftbulletScript.target = FindClosestTransform();
        }
        if (rightbulletScript != null)
        {
            rightbulletScript.target = FindClosestTransform();
        }
    }


    public Transform FindClosestTransform()
    {
        if (enemiesInRange.Count == 0)
        {
            return null;
        }
        Transform closest = null;
        float closestDistance = 1000f;
        
        foreach(Transform t in enemiesInRange)
        {
            float distance = Vector3.Distance(t.position, transform.position);
            if(distance < closestDistance)
            {
                closest = t;
                closestDistance = distance;
            }
            
        }
        return closest;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemiesInRange.Add(collision.transform);
            //Debug.Log("Enemy has enter the Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            enemiesInRange.Remove(collision.transform);
        }


    }


}
