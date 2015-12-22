using UnityEngine;
using System.Collections;

public class minionCollisions : MonoBehaviour {
    public int dmg;

	// Use this for initialization
	void Start () {
        dmg = GetComponent<minionStats>().dmg;
	}

    void OnCollisionEnter2D (Collision2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
        }

    }
}
