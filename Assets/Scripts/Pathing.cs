using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathing : MonoBehaviour
{
    public List<Transform> wayPoints;
    public float moveSpeed;
    public int currentWaypointIndex;

    private void Update()
    {
        MoveWaypoint();
    }

    public void MoveWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoints[currentWaypointIndex].position, moveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoints[currentWaypointIndex].position) < 0.1f)
        {
            if (currentWaypointIndex < wayPoints.Count - 1)
            {
                currentWaypointIndex = currentWaypointIndex + 1;
            }
        }
    }

}
