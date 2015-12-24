using UnityEngine;
using System.Collections;

public class pistolShooting : basicShooting {
    
	// Update is called once per frame
	override protected void Update () {
        base.Update();

        if (Input.GetMouseButtonDown(0)) { //Left Click
            SpawnBullet();
            sound.Play();
        }

	}

}
