using UnityEngine;
using System.Collections;

public class movement : MonoBehaviour {
    [SerializeField]
    private float speed;
    private Rigidbody2D rb;
    private Sprite[] spriteSheet;
    private SpriteRenderer sr;
    // Use this for initialization
    void Start () {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        rb.velocity = new Vector2(horz, vert) * speed;

	}
}
