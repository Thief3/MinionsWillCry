using UnityEngine;
using System.Collections;

public class laserController : MonoBehaviour {
    public float stayOnScreenForXSecs;
    public float angle;
    private float timer;
    private SpriteRenderer sr;
    //private int parentOrder;
    

    // Use this for initialization
    void Start () {
        timer = 0f;
        sr = GetComponent<SpriteRenderer>();
        //parentOrder = transform.parent.gameObject.GetComponent<SpriteRenderer>().sortingOrder;
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer >= stayOnScreenForXSecs) {
            Destroy(gameObject);
        }

        //if (angle >= 0) {
        //    sr.sortingOrder = parentOrder- 1;
        //}
        //else if (angle < 0) {
        //    sr.sortingOrder = parentOrder + 1;
        //}
    }
}
