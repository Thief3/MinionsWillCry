﻿using UnityEngine;
using System.Collections;

public class medKitDropCollision : MonoBehaviour {
    public int heal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D coll) {
        string tag = coll.gameObject.tag;

        if (tag == "Player") {
            coll.gameObject.GetComponent<gruStats>().LoseHealth(-heal);
            Destroy(gameObject);
        }
    }
}
