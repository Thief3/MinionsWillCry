using UnityEngine;
using System.Collections;

public class basicShooting : MonoBehaviour {
    protected Vector2 direction;
    public GameObject mainBullet;
    private float width;

    // Use this for initialization
    virtual protected void Start () {
        width = GetComponent<SpriteRenderer>().sprite.rect.width;
    }
	
	// Update is called once per frame
	virtual protected void Update () {
        GetDirection();
	}

    virtual protected void GetDirection () {
        Vector3 mousePos = Input.mousePosition;

        direction = (mousePos - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    virtual protected void SpawnBullet() {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 bulletStartPoint = currentPosition + direction * width / 100;
        GameObject bullet = Instantiate(mainBullet, bulletStartPoint, Quaternion.identity) as GameObject;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<friendlyBulletCollisions>().combo = GetComponent<gunStats>().combo;
    }

}
