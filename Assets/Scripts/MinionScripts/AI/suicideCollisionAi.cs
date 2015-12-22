using UnityEngine;
using System.Collections;

public class suicideCollisionAi : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
            Destroy(gameObject);
        }

    }
}
