﻿using UnityEngine;
using System.Collections;

public class bulletCode : MonoBehaviour {
    [SerializeField]
    private float speed;
    [SerializeField]
    private int dmg;

    private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = transform.right * speed;
    }
}
