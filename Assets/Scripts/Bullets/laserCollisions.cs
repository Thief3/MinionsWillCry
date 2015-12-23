using UnityEngine;
using System.Collections;

public class laserCollisions : MonoBehaviour {
    public int dmg;
    public float stayOnScreenForXSecs;
    private float timer;

	// Use this for initialization
	void Start () {
        timer = 0f;
	}

    void Update() {
        timer += Time.deltaTime;
        if (timer >= stayOnScreenForXSecs) {
            Destroy(gameObject);
        }
    }
	
	void OnTriggerEnter2D (Collider2D coll) {
        string tag = coll.gameObject.tag;

        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
        }

    }
}
