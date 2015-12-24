using UnityEngine;
using System.Collections;

public class explosionCollision : MonoBehaviour {
    public int dmg;
   
    void Start() {

    }

    void OnTriggerEnter2D(Collider2D coll) {
        string tag = coll.gameObject.tag;
        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(dmg);
        }

        else if (tag == "Enemy") {
            coll.gameObject.GetComponent<minionStats>().LoseHealth(dmg);
        }
        else if (tag == "Barrel") {
            coll.gameObject.GetComponent<barrel>().LoseHealth(dmg);
        }
    }

}
