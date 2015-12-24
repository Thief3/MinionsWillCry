using UnityEngine;
using System.Collections;

public class movementAnimation : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator anim;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (rb.velocity.x > 0) {
            anim.SetInteger("Walking", 1);
            anim.ResetTrigger("BecomeIdle");
        }

        else if (rb.velocity.x < 0) {
            //Debug.Log("Hello?");
            anim.SetInteger("Walking", -1);
            anim.ResetTrigger("BecomeIdle");
        }
        else {
            anim.SetTrigger("BecomeIdle");
            
        }
    }

}
