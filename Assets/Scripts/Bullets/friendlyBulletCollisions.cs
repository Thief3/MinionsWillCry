using UnityEngine;
using System.Collections;

public class friendlyBulletCollisions : MonoBehaviour {
    public int dmg;
    public GameObject combo;
    private styleCombos comboF;

	// Use this for initialization
	void Start () {
        comboF = combo.GetComponent<styleCombos>();
	}
	
    void OnCollisionEnter2D (Collision2D coll) {
        string tag = coll.gameObject.tag;

        if (tag == "Enemy") {
            coll.gameObject.GetComponent<minionStats>().LoseHealth(dmg);
            comboF.AddHit();
            Destroy(gameObject);
        }

        if (tag != "Player") {
            Destroy(gameObject);
        }
    }

    void OnInvisible() {
        Destroy(gameObject);
    }
}
