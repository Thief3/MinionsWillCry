using UnityEngine;
using System.Collections;

public class suicideCollisionAi : MonoBehaviour {
    public GameObject explosion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "Player") {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }
}
