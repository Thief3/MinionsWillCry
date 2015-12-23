using UnityEngine;
using System.Collections;

public class rangerAttackAi : MonoBehaviour {
    public float shotDistance;
    public float shotDelay;
    public float chargeTime;
    public GameObject laserObj;
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
        target = GetComponent<minionStats>().gru;
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

            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            Vector3 laserPos = transform.position + new Vector3(0.06f, 0.09f, 0f);
            GameObject laser = Instantiate(laserObj, laserPos, Quaternion.identity) as GameObject;
            laser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            laser.transform.parent = transform;
            laser.GetComponent<laserController>().angle = angle;
            laser.GetComponent<laserCollisions>().dmg = dmg;

            charging = false;
            chargeTimer = 0f;

        }
        else if (charging == true) {
            chargeTimer += Time.deltaTime;

        }
    }
}
