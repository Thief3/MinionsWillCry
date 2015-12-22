using UnityEngine;
using System.Collections;
using Pathfinding;

public class zombieAi : MonoBehaviour {
    public Vector3 target;

    private Seeker seeker;

    public Path path;

    public float speed, distanceToNextWaypoint;

    private int currentWaypoint;
    private Rigidbody2D rb;

    void Start() {
        currentWaypoint = 0;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        seeker.StartPath(transform.position, target, OnPathComplete);
    }

    public void OnPathComplete(Path p) {
        path = p;
    }

    void Update () {
        if (path == null) {
            Debug.Log("Yeah it didn't work....");
        }
        else if (currentWaypoint >= path.vectorPath.Count) {
            Debug.Log("Done...?");
        }

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        rb.velocity = speed * dir;

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < distanceToNextWaypoint) {
            currentWaypoint++;
        }
    }


}
