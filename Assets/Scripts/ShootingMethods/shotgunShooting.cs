using UnityEngine;
using System.Collections;

public class shotgunShooting : MonoBehaviour {
    [SerializeField]
    private GameObject mainBullet;

    // Update is called once per frame
    void Update() {
        Vector3 mousePos = Input.mousePosition;

        Vector3 direction = mousePos - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.GetMouseButtonDown(0)) { //Left Click
            for (int i = 0; i < 5; i++) {
                float bulletAngle = (Mathf.Atan2(direction.y, direction.x) + Random.Range(-(Mathf.PI / 4), (Mathf.PI / 4))) * Mathf.Rad2Deg;

                GameObject bullet = Instantiate(mainBullet, transform.position, Quaternion.identity) as GameObject;
                bullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
            }
        }

    }
}
