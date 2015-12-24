using UnityEngine;
using System.Collections;

public class barrel : MonoBehaviour {
    public GameObject releasesPrefab;
    public int health;
    private Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoseHealth(int dmg) {

        if (health - dmg > 0) {
            health -= dmg;
            anim.SetTrigger("Hit");
        }

        if (health - dmg <= 0) {
            //die animation;
            if (releasesPrefab != null) {
                Instantiate(releasesPrefab, transform.position, Quaternion.identity);
            }

            anim.SetTrigger("Die");

            Destroy(gameObject);
        }
    }
}
