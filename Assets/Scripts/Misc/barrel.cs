using UnityEngine;
using System.Collections;

public class barrel : MonoBehaviour {
    public GameObject releasesPrefab;
    public int health;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoseHealth(int dmg) {
        health -= dmg;
        if (health <= 0) {
            //die animation;
            if (releasesPrefab != null) {
                Instantiate(releasesPrefab, transform.position, Quaternion.identity);
            }
            Destroy(gameObject);
        }
    }
}
