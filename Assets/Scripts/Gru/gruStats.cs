using UnityEngine;
using System.Collections;

public class gruStats : MonoBehaviour {
    public int health;
    public GameObject gun;
    public GameObject combo;
    public styleCombos combof;

	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoseHealth(int hitValue) {
        combof.ResetPoints();
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

    public void gunChange(GameObject gunPrefab) {
        if (gun != gunPrefab) {
            if (gun != null) {
                Destroy(gun);
            }
            gun = Instantiate(gunPrefab, transform.position, Quaternion.identity) as GameObject;
            gun.transform.parent = transform;
            gun.GetComponent<gunStats>().combo = combo;

            combof.ResetMulit();
        }
    }
}
