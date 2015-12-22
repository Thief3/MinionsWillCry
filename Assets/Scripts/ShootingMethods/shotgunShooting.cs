using UnityEngine;
using System.Collections;

public class shotgunShooting : basicShooting {

    // Update is called once per frame
    override protected void Update() {
        base.Update();

        if (Input.GetMouseButtonDown(0)) { //Left Click
                SpawnBullet();
        }

    }

    protected override void SpawnBullet() {
        for (int i = 0; i < 5; i++) {
            float bulletAngle = (Mathf.Atan2(direction.y, direction.x) + Random.Range(-(Mathf.PI / 4), (Mathf.PI / 4))) * Mathf.Rad2Deg;

            Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
            Vector2 bulletStartPoint = currentPosition + direction * width / 100;
            GameObject bullet = Instantiate(mainBullet, bulletStartPoint, Quaternion.identity) as GameObject;
            bullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
            bullet.GetComponent<friendlyBulletCollisions>().combo = GetComponent<gunStats>().combo;

        }
    }
}
