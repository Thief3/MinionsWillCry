using UnityEngine;
using System.Collections;

public class cameraScript : MonoBehaviour {
    public GameObject gruPrefab;
    private GameObject gru;
    // Use this for initialization
	void Start () {
        gru = Instantiate(gruPrefab) as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3 (gru.transform.position.x, gru.transform.position.y, transform.position.z);
	}
}
