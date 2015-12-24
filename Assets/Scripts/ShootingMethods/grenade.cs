using UnityEngine;
using System.Collections;

public class grenade : MonoBehaviour {
    public float time;
    private float timer;
    private GameObject grenadePrefab;
    private Rigidbody2D rb;
    public gruStats gru;

    protected void Start() {
        rb = GetComponent<Rigidbody2D>();
        gru = transform.parent.gameObject.GetComponent<gruStats>();
    }

    // Update is called once per frame
    protected void Update() {
        
        if (Input.GetMouseButtonDown(1) && gru.numOfGrenades != 0) { //Left Click
            SpawnBullet();
            gru.numOfGrenades--;
        }
    }

    protected void SpawnBullet() {
        Vector3 mousePos = Input.mousePosition;

        Vector3 direction = (mousePos - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        GameObject grenadeObj = Instantiate(grenadePrefab, currentPosition, Quaternion.identity) as GameObject;
        grenadeObj.transform.rotation = transform.rotation;
    }
}
