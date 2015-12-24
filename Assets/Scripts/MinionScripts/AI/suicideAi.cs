using UnityEngine;
using System.Collections;

public class suicideAi : MonoBehaviour {
    public minionStats stats;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        stats = GetComponent<minionStats>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (stats.health <= 0) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
