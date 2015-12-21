using UnityEngine;
using System.Collections;

public class gruCollisions : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D (Collision2D coll) {
        // if gru picks up a new weapon, then reset the comboMulti
        // if gru gets hit then resetTheCombo
    }
}
