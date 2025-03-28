using UnityEngine;

public class Path : MonoBehaviour
{
    public Transform[] waypoints;
    private int currentWaypoint = 0;
    public float speed = 5f;

    void Update()
    {
        if (currentWaypoint < waypoints.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypoint].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, waypoints[currentWaypoint].position) < 0.1f)
            {
                currentWaypoint++;
            }
        }
    }
}
