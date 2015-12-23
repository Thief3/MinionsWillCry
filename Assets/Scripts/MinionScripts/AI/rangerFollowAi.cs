using UnityEngine;
using System.Collections;
using Pathfinding;

public class rangerFollowAi : MonoBehaviour {
    public GameObject target;

    public Path path;
    private Seeker seeker;

    public float distanceToNextWaypoint, repathRate, deltaTime;
    private float speed;

    public float targetDistance, allowance;
    private int currentWaypoint;
    private bool requesting;//, stopChecking;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        speed = GetComponent<minionStats>().speed;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        target = GetComponent<minionStats>().gru;

        //stopChecking = false;
        currentWaypoint = 0;
        deltaTime = 0f;

        requesting = true;
        seeker.StartPath(transform.position, target.transform.position, OnPathComplete);
    }

    void Update() {
        deltaTime += Time.deltaTime;

        float distance = Vector3.Distance(target.transform.position, transform.position);

        //Debug.Log(distance);

        if (distance > targetDistance + allowance) {
            //Debug.Log("State:Approching");
            CheckRedo(target.transform.position);
        }

        else if (distance < targetDistance - allowance) {
            //Debug.Log("State:Fleeing");
            Vector3 fleeDirection = (transform.position - target.transform.position).normalized;
            Vector3 fleeTarget = transform.position + fleeDirection * targetDistance;

            CheckRedo(fleeTarget);
        }

        else {
            rb.velocity = new Vector2(0, 0);
        }

        //TranversePath();

    }

    void RedoPath(Vector3 targetPos) {
        //Debug.Log("Redone");
        if (requesting == false) {
            requesting = true;
            seeker.StartPath(transform.position, targetPos, OnPathComplete);
        }

    }

    void CheckRedo(Vector3 targetPos) {
        if (deltaTime > repathRate) {
            RedoPath(targetPos);
        }

        if (path == null) {
            RedoPath(targetPos);
        }
        else if (currentWaypoint >= path.vectorPath.Count) {
            RedoPath(targetPos);

        }

        TranversePath(targetPos);

    }

    void TranversePath(Vector2 targetPos) {

        Vector3 dir = (path.vectorPath[currentWaypoint] - transform.position).normalized;
        //Debug.Log(dir);
        rb.velocity = speed * dir;

        if (Vector3.Distance(transform.position,
            path.vectorPath[currentWaypoint]) < distanceToNextWaypoint) {
            currentWaypoint++;
        }
    }

    public void OnPathComplete(Path p) {
        path = p;
        currentWaypoint = 0;
        deltaTime = 0f;
        requesting = false;
    }
}
