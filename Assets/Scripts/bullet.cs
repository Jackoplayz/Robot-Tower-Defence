using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float bulletSpeed;
    public int bulletDamage;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector2 direction = target.position - transform.position;
        float distance = bulletSpeed * Time.deltaTime;

        if (direction.magnitude <= distance)
        {
            HitTarget();
            return;
        }

        transform.Translate(direction.normalized * distance, Space.World);
    }

    void HitTarget()
    {
        Enemy targetEnemy = target.GetComponent<Enemy>();
        if (targetEnemy != null)
        {
            targetEnemy.takeDamage(bulletDamage);
        }
        Destroy(gameObject);
    }


}
