using UnityEngine;
using System.Collections;

public class explosionCollision : MonoBehaviour {
    public int dmg;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D (Collider2D coll) {
        Debug.Log("h");
        string tag = coll.gameObject.tag;
        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
        }
        else if (tag == "Enemy") {
            coll.gameObject.GetComponent<minionStats>().LoseHealth(dmg);
        }

        Destroy(gameObject);
    }

}
