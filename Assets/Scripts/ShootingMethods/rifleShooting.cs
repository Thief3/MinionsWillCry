using UnityEngine;
using System.Collections;

public class rifleShooting : MonoBehaviour {
    public GameObject mainBullet;
    public float delayTime;
    public int shotsInBurst;
    private float deltaTime;
    private int currentShots;

    void Start() {
        deltaTime = 0;
        currentShots = 0;
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;

        Vector3 direction = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        deltaTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) & deltaTime <= 0 & currentShots < shotsInBurst) { //Left Click
            GameObject bullet = Instantiate(mainBullet, transform.position, Quaternion.identity) as GameObject;
            bullet.transform.rotation = transform.rotation;
            bullet.GetComponent<friendlyBulletCollisions>().combo = GetComponent<gunStats>().combo;

            deltaTime = delayTime;
            currentShots++;
        }

        if (Input.GetMouseButtonUp(0)) {
            currentShots = 0;
        }
    }
}
