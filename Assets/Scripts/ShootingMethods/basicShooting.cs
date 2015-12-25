using UnityEngine;
using System.Collections;

public class basicShooting : MonoBehaviour {
    protected Vector2 direction;
    public GameObject mainBullet;
    protected float width;
    protected GameObject bullet;
    protected SpriteRenderer sr;
    protected SpriteRenderer gruSr;
    protected AudioSource sound;
    protected gunStats stats;

    // Use this for initialization
    virtual protected void Start () {
        sound = GetComponent<AudioSource>();
        width = GetComponent<SpriteRenderer>().sprite.rect.width;
        sr = GetComponent<SpriteRenderer>();
        gruSr = transform.parent.gameObject.GetComponent<SpriteRenderer>();
        stats = GetComponent<gunStats>();
    }
	
	// Update is called once per frame
	virtual protected void Update () {
        GetDirection();
        UpdateGunLayer();
	}

    virtual protected void GetDirection () {
        Vector3 mousePos = Input.mousePosition;

        direction = (mousePos - Camera.main.WorldToScreenPoint(transform.position)).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }

    virtual protected void SpawnBullet() {
        Vector2 currentPosition = new Vector2(transform.position.x, transform.position.y);
        Vector2 bulletStartPoint = currentPosition + direction * (width + 2) / 100;
        bullet = Instantiate(mainBullet, bulletStartPoint, Quaternion.identity) as GameObject;
        bullet.transform.rotation = transform.rotation;
        bullet.GetComponent<friendlyBulletCollisions>().combo = GetComponent<gunStats>().combo;

        
    }

    virtual protected void UpdateGunLayer() {
        if (Mathf.Atan2(direction.y, direction.x) > 0){
            sr.sortingOrder = gruSr.sortingOrder - 1;
        }
        else {
            sr.sortingOrder = gruSr.sortingOrder + 1;
        }

        if (direction.x >= 0) {
            sr.sprite = stats.right;
        }
        else {
            sr.sprite = stats.left;
        }

    }

}
