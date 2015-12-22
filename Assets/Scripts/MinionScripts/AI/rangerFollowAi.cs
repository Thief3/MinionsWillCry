using UnityEngine;
using System.Collections;
using Pathfinding;

public class rangerFollowAi : MonoBehaviour {
    public GameObject target;

    private Seeker seeker;

    public Path path;

    private float speed;
    public float distanceToNextWaypoint, repathRate, deltaTime;

    private int currentWaypoint;

    private Rigidbody2D rb;

    private bool requesting, stopChecking;

    public float radiusToRunBack, radiusToStopChecking;


	// Use this for initialization
	void Start () {
        speed = GetComponent<minionStats>().speed;
        stopChecking = false;
        currentWaypoint = 0;
        deltaTime = 0f;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        target = GetComponent<minionStats>().gru;

        requesting = true;
        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
    }

    public void OnPathComplete(Path p) {
        path = p;
        currentWaypoint = 0;
        deltaTime = 0f;
        requesting = false;
    }

    void Update() {
        deltaTime += Time.deltaTime;

        if (!stopChecking) {

            if (deltaTime > repathRate) {
                RedoPath();
            }

            //seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
            if (path == null) {
                RedoPath();
            }
            else if (currentWaypoint >= path.vectorPath.Count) {
                RedoPath();

            }

            Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
            rb.velocity = speed * dir;

            if (Vector3.Distance(transform.position,
                path.vectorPath[currentWaypoint]) < distanceToNextWaypoint) {
                currentWaypoint++;
            }
        }

        if (Vector3.Distance(transform.position,
            path.vectorPath[currentWaypoint]) < radiusToStopChecking) {

            stopChecking = true;

        }

        else if (Vector3.Distance(transform.position,
            path.vectorPath[currentWaypoint]) >= radiusToStopChecking * 1.5) {

            stopChecking = false;

            RedoPath();
        }

        else if (Vector3.Distance(transform.position,
            path.vectorPath[currentWaypoint]) < radiusToRunBack) {

            Vector2 reverseDir = -(transform.position - target.transform.position).normalized;
            rb.velocity = speed * reverseDir;

        }
    }

    void RedoPath() {
        if (requesting == false) {
            requesting = true;
            seeker.StartPath(transform.position, target.transform.position, OnPathComplete);


        }

    }
}
