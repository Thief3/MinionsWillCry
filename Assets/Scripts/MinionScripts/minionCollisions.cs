using UnityEngine;
using System.Collections;

public class minionCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter2D (Collision2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "FriendlyBullet") {

        }
        else if (tag == "Player") {
            
        }

    }
}
