using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaCannon : MonoBehaviour
{
    public bool isLazer;
    public Transform laserOrigin;
    
    public float damagePerSecond;
    public LineRenderer myLineRenderer;
  

    public List<Transform> laserEnemiesInRange = new List<Transform>();
    //public float Range; do later
    //public float Reload; do later.

    // Start is called before the first frame update
    void Start()
    {
        if (myLineRenderer == null)
        {
            myLineRenderer = GetComponent<LineRenderer>();
        }
        myLineRenderer.positionCount = 2;
        myLineRenderer.enabled = false;
        myLineRenderer.startWidth = 1;
        myLineRenderer.endWidth = 1;
    }

    // Update is called once per frame
    void Update()
    {
        AimAtTarget();
        Transform target = FindClosestTransform();
        if (target != null )
        {
            myLineRenderer.enabled = true;
            myLineRenderer.SetPosition(0, laserOrigin.position);
            myLineRenderer.SetPosition(1, target.position);

            Enemy myEnemy = target.GetComponent<Enemy>();
            if (myEnemy != null)
            {
                myEnemy.TakeDamage(damagePerSecond * Time.deltaTime);
            }


        }
        else
        {
            myLineRenderer.enabled = false;
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
        laserEnemiesInRange.Remove(enemyTransform);
    }

   


    public Transform FindClosestTransform()
    {
        for (int i = laserEnemiesInRange.Count - 1; i >= 0; i--)
        {
            if (laserEnemiesInRange[i] == null)
            {
                laserEnemiesInRange.RemoveAt(i);
            }
        }
        if (laserEnemiesInRange.Count == 0)
        {
            return null;
        }
        Transform closest = null;
        float closestDistance = 1000f;

        foreach (Transform t in laserEnemiesInRange)
        {
            if (t == null)
            {
                continue;
            }
            float distance = Vector3.Distance(t.position, transform.position);
            if (distance < closestDistance)
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
            laserEnemiesInRange.Add(collision.transform);
            //Debug.Log("Enemy has enter the Range");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            laserEnemiesInRange.Remove(collision.transform);
        }


    }

}
