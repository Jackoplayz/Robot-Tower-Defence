using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float health;
    public EnemyManager myEnemyManager;


    public void Start()
    {
        myEnemyManager = FindObjectOfType<EnemyManager>();
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Death();
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Death();
        }
    }
    public void NotifyTurretsOfDeath()
    {
        Turret[] allTurrets = FindObjectsOfType<Turret>();
        foreach(Turret turret in allTurrets)
        {
            turret.RemoveEnemyFromList(transform);
        }
    }

    public void Death()
    {
        NotifyTurretsOfDeath();
        myEnemyManager.aliveEnemyList.Remove(this);
        Destroy(gameObject);
    }
    
    public void DestroyWithTeleport()
    {
        Vector3 teleportLocation = new Vector3(1000,1000,1000);
        transform.position = teleportLocation;
        Invoke("death", 1f);

    }
}
