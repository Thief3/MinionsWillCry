using UnityEngine;
using System.Collections;

public class gruStats : MonoBehaviour {
    public int health;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoseHealth(int hitValue) {
        if (health - hitValue > 0) {
            health -= hitValue;
        }
        else {
            health = 0;
            DestroySelf();
        }
    }

    public void DestroySelf() {
    }
}
