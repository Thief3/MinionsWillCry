using UnityEngine;
using System.Collections;
using Pathfinding;

public class zombieAi : MonoBehaviour {
    public GameObject target;

    private Seeker seeker;

    public Path path;

    private float speed;
    public float distanceToNextWaypoint, repathRate, deltaTime;

    private int currentWaypoint;
    private Rigidbody2D rb;

    private bool requesting;

    void Start() {
        speed = GetComponent<minionStats>().speed;
        currentWaypoint = 0;
        deltaTime = 0f;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        target = GetComponent<minionStats>().gru;

        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
    }

    public void OnPathComplete(Path p) {
        path = p;
        currentWaypoint = 0;
        deltaTime = 0f;
        Debug.Log("Path redone.");
        requesting = false;
    }

    void Update () {
        deltaTime += Time.deltaTime;
        if (deltaTime > repathRate) {
            RedoPath();
        }

        //seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
        if (path == null) {
            Debug.Log("Yeah it didn't work....");
            RedoPath();
        }
        else if (currentWaypoint >= path.vectorPath.Count) {
            Debug.Log("Done...?");
            RedoPath();
            
        }

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        rb.velocity = speed * dir;

        if (Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < distanceToNextWaypoint) {
            Debug.Log("Next!");
            currentWaypoint++;
        }
    }

    void RedoPath() {
        if (requesting == false) {
            requesting = true;
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
            

        }

    }

    //void OnCollisionEnter2D (Collision2D coll) {
    //    RedoPath();
   // }
}
