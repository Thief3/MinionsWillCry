using UnityEngine;
using System.Collections;

public class layerController : MonoBehaviour {
    public float gridSize;
    private SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        
	}
	
	// Update is called once per frame
	void Update () {
        float layer = (transform.position.y - sr.bounds.size.y/2) / gridSize;
        sr.sortingOrder = -Mathf.RoundToInt(layer);
    }
}
