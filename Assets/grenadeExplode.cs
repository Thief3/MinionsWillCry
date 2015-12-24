using UnityEngine;
using System.Collections;

public class grenadeExplode : MonoBehaviour {
    public float timeTillExplosion;
    public GameObject explosion;
    private float timer;
	// Use this for initialization
	void Start () {
        timer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= timeTillExplosion) {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
	}
}
