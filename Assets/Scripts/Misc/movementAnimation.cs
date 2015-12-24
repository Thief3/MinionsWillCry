using UnityEngine;
using System.Collections;

public class movementAnimation : MonoBehaviour {
    private Rigidbody2D rb;
    private Animator anim;
    private Vector3 lastPos;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        lastPos = new Vector3(0f, 0f, 0f);
    }
	
	// Update is called once per frame
	void Update () {
        if (lastPos != transform.position) {
            anim.SetTrigger("StartWalking");
        }


        if (rb.velocity.x > 0) {
            anim.SetInteger("Walking", 1);
            anim.ResetTrigger("BecomeIdle");
        }

        else if (rb.velocity.x < 0) {
            //Debug.Log("Hello?");
            anim.SetInteger("Walking", -1);
            anim.ResetTrigger("BecomeIdle");
        }
        else if (rb.velocity.y == 0){
            anim.SetTrigger("BecomeIdle");
            
        }
    }

}
