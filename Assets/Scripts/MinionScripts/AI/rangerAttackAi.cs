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
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
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

            Vector3 laserPos = new Vector3 (0f, 0f, 0f);
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (anim.GetInteger("Walking") == 1) {
                //Debug.Log("Moving 1");
                laserPos = new Vector3(0.05f, 0.07f, 0f);
            }
            else if (anim.GetInteger("Walking") == -1) {
                //Debug.Log("Moving -1");
                laserPos = new Vector3(-0.05f, 0.08f, 0f);
            }
            GameObject laser = Instantiate(laserObj, transform.position, Quaternion.identity) as GameObject;
            laser.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            laser.transform.parent = transform;

            laser.transform.localPosition = laserPos;

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
