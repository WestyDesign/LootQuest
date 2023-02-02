#region 'Using' information
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#endregion

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; // the number of points that the platform moves between. set in inspector.
    
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2; // the speed at which the platforms move

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length) // loop back to the first waypoint after touching the final one
            {
                currentWaypointIndex = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}