using UnityEngine;
using System.Collections;

public class gruStats : MonoBehaviour {
    public int health;
    public GameObject gun;
    public GameObject combo;
    public styleCombos combof;
    public int numOfGrenades;
    private Animator anim;
    private Rigidbody2D rb;
    private bool died;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoseHealth(int hitValue) {
        combof.ResetPoints();
        if (health - hitValue >= 100) {
            health = 100;
            
        }
        else if (health - hitValue > 0) {
            health -= hitValue;
            anim.SetTrigger("Hit");
        }
        else {
            health = 0;
            DestroySelf();
        }
    }

    public void DestroySelf() {
        anim.SetTrigger("Die");
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
