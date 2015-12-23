using UnityEngine;
using System.Collections;

public class testDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(0)) {
            GetComponent<Animator>().SetBool("die", true);
        }
        else if (Input.GetMouseButtonUp(0)) {
            GetComponent<Animator>().SetBool("die", false);
        }

	}
}
