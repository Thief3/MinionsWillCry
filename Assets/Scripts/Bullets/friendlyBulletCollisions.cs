using UnityEngine;
using System.Collections;

public class friendlyBulletCollisions : MonoBehaviour {
    public int dmg;
    public GameObject combo;
    private styleCombos comboF;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        comboF = combo.GetComponent<styleCombos>();
	}
	
    void OnCollisionEnter2D (Collision2D coll) {
        string tag = coll.gameObject.tag;

        if (tag == "Enemy") {
            coll.gameObject.GetComponent<minionStats>().LoseHealth(dmg);
            comboF.AddHit();
        }
        else if (tag == "Barrel") {
            coll.gameObject.GetComponent<barrel>().LoseHealth(dmg);
        }


        if (tag != "Player") {
            anim.SetTrigger("Die");

            Destroy(gameObject);
        }

    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
