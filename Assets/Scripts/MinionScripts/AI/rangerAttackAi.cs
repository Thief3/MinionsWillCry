using UnityEngine;
using System.Collections;

public class rangerAttackAi : MonoBehaviour {
    public float shotDistance;
    public float shotDelay;
    public float chargeTime;
    public float laser;
    private float chargeTimer;
    private bool charging;
    private float deltaTime;
    private GameObject target;
    private Vector3 dir;
    private int dmg;

    // Use this for initialization
    void Start() {
        charging = false;
        deltaTime = 0f;
        dmg = GetComponent<minionStats>().dmg;
        target = GetComponent<rangerFollowAi>().target;
    }

    // Update is called once per frame
    void Update() {
        deltaTime += Time.deltaTime;

        if (Vector3.Distance(target.transform.position, transform.position) <= shotDistance
            && deltaTime >= shotDelay) {

            deltaTime = 0f;

            dir = (target.transform.position - transform.position).normalized;

            charging = true;

        }

        if (charging == true
            && chargeTimer >= chargeTime) {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir * shotDistance);
            if (hit.collider.tag == "Player") {
                hit.collider.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
            }

            charging = false;

        }
        else if (charging == true) {
            chargeTimer += Time.deltaTime;

        }
    }
}
