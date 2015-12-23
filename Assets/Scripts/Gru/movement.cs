using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    public float speed;
    private Rigidbody2D rb;
    private Sprite[] spriteSheet;
    private SpriteRenderer sr;
    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horz, vert) * speed;

       // if (horz == 0f && vert == 0f) {
       //     anim.SetBool("moving", false);
       // }
       // else {
       //     anim.SetBool("moving", true);
       // }

	}
}
