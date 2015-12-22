using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour {
    public GameObject characterToFollow;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector2 (characterToFollow.transform.position.x, characterToFollow.transform.position.y);
	}
}
