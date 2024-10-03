using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    
    public void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            death();
        }
    }

    public void death()
    {
        Destroy(gameObject);
    }
    
    public void destroyWithTeleport()
    {
        Vector3 teleportLocation = new Vector3(1000,1000,1000);
        transform.position = teleportLocation;
        Invoke("death", 1f);

    }
}
