using UnityEngine;
using System.Collections;

public class rifleShooting : basicShooting {
    public float delayTime;
    public int shotsInBurst;
    private float deltaTime;
    private int currentShots;
    private bool bursting;

    override protected void Start() {
        base.Start();
        bursting = false;
        deltaTime = 0;
        currentShots = 0;
    }

    override protected void Update() {
        base.Update();

        deltaTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) & deltaTime <= 0 & currentShots < shotsInBurst) { //Left Click
            SpawnBullet();

            deltaTime = delayTime;
            currentShots++;
            if (bursting == false) {
                sound.Play();
                bursting = true;
            }
        }

        if (Input.GetMouseButtonUp(0)) {
            currentShots = 0;
            bursting = false;
        }
    }
}
