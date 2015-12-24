using UnityEngine;
using System.Collections;

public class grenadeThrow : MonoBehaviour {
    public int numOfGrenades;
    public float force;
    public GameObject grenade;
    public gruStats gru;

    protected void Start() {
        gru = transform.parent.gameObject.GetComponent<gruStats>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButtonDown(1) && gru.numOfGrenades > 0) {
            Vector3 mousePos = Input.mousePosition;

            Vector3 direction = (mousePos - Camera.main.WorldToScreenPoint(transform.position)).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GameObject grenadeObj = Instantiate(grenade, transform.position, Quaternion.identity) as GameObject;
            grenadeObj.transform.rotation = transform.rotation;
            grenadeObj.GetComponent<Rigidbody2D>().velocity = direction * force;
            gru.numOfGrenades--;

        }
	}
}
