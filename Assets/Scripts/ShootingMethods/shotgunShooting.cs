using UnityEngine;
using System.Collections;

public class shotgunShooting : basicShooting {
    // TODO FIX THIS PILE OF SHIT;
    // Update is called once per frame
    public int numberOfShells;
    override protected void Update() {
        base.Update();

        if (Input.GetMouseButtonDown(0)) { //Left Click
            for (int i = 0; i < numberOfShells; i++){
                SpawnBullet();
            }
        }

    }

    protected override void SpawnBullet() {
        
        base.SpawnBullet();
        float bulletAngle = (Mathf.Atan2(direction.y, direction.x) + Random.Range(-(Mathf.PI / 4), (Mathf.PI / 4))) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.AngleAxis(bulletAngle, Vector3.forward);
        sound.Play();
    }
}
