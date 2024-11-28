using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    public GameObject stunProjectilePrefab;
    public float stunDuration;
    public float timer;
    public float timeBeforeShooting;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= timeBeforeShooting)
        {
            ShootStunRocket();
            timer = 0f;
        }
    }


   public void ShootStunRocket()
    {
        Turret closestTurret = FindClosestTurret();
        if (closestTurret != null)
        {
            GameObject projectile = Instantiate(stunProjectilePrefab,transform.position,Quaternion.identity);
            projectile.GetComponent<StunRocket>().target = closestTurret.transform;
        }
    }

    public Turret FindClosestTurret()
    {
        Turret[] turretList = FindObjectsOfType<Turret>();
        Turret closestTurret = null;
        float closestDistance = 9999f;
        foreach(Turret turret in turretList)
        {
            float distance = Vector3.Distance(transform.position, turret.transform.position);
            if (distance < closestDistance)
            {
                closestTurret = turret;
                closestDistance = distance;
            }
        }
        return closestTurret;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
