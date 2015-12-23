using UnityEngine;
using System.Collections;

public class gruCollisions : MonoBehaviour {
    private styleCombos combo;

	// Use this for initialization
	void Start () {
        combo = GetComponent<gruStats>().combo.GetComponent<styleCombos>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
