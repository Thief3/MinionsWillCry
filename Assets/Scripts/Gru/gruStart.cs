using UnityEngine;
using System.Collections;

public class gruStart : MonoBehaviour {
    public GameObject combo;
    public GameObject startingGun;
    public GameObject score;
    public GameObject spawner;

    // Use this for initialization
    void Start() {
        GameObject comboObject = Instantiate(combo) as GameObject;
        GameObject gun = Instantiate(startingGun, transform.position, Quaternion.identity) as GameObject;
        gun.transform.parent = transform;
        gun.GetComponent<gunStats>().combo = comboObject;

        Instantiate(score);
        Instantiate(spawner);
    }

    // Update is called once per frame
    void Update() {

    }
}
