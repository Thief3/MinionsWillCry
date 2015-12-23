using UnityEngine;
using System.Collections;

public class laserCollisions : MonoBehaviour {
    public int dmg;

	// Use this for initialization
	void Start () {
	}
	
	void OnTriggerEnter2D (Collider2D coll) {
        string tag = coll.gameObject.tag;

        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
        }

    }
}
