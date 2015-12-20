using UnityEngine;
using System.Collections;

public class smgShooting : MonoBehaviour {
    [SerializeField]
    private GameObject mainBullet;
    [SerializeField]
    private float delayTime;
    private float deltaTime;
    

    void Start() {
        deltaTime = 0;
    }

    void Update() {
        Vector3 mousePos = Input.mousePosition;

        Vector3 direction = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        deltaTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) & deltaTime <= 0) { //Left Click
            GameObject bullet = Instantiate(mainBullet, transform.position, Quaternion.identity) as GameObject;
            bullet.transform.rotation = transform.rotation;

            deltaTime = delayTime;
        }
    }
}
