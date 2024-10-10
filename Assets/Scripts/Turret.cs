using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
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
        shootCountdown += Time.deltaTime;
        if (shootCountdown >= shootDelay)
        {
            ShootBullet();
            shootCountdown -= shootDelay;
        }
    }

    private void ShootBullet()
    {
        GameObject shotBullet = Instantiate(bulletPrefab);
        bullet bulletScript = shotBullet.GetComponent<bullet>();
        if (bulletScript != null)
        {
            bulletScript.target = FindClosestTransform();
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
