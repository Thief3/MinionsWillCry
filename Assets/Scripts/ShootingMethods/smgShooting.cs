using UnityEngine;
using System.Collections;

public class smgShooting : basicShooting {
    // Could/Should probs make a automatic shooting class.
    public float delayTime;
    private float deltaTime;
    

    override protected void Start() {
        base.Start();
        deltaTime = 0f;
    }

    override protected void Update() {
        base.Update();

        deltaTime -= Time.deltaTime;

        if (Input.GetMouseButton(0) & deltaTime <= 0) { //Left Click
            SpawnBullet();
            sound.Play();

            deltaTime = delayTime;
        }
    }
}
