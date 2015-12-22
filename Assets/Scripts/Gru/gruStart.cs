using UnityEngine;
using System.Collections;

public class gruStart : MonoBehaviour {
    public GameObject combo;
    public GameObject startingGun;
    public float armLength;
    //public GameObject score;
    //public GameObject spawner;
    //public GameObject arm;

    // Use this for initialization
    void Start() {
        GameObject comboObject = Instantiate(combo) as GameObject;
        //Vector2 gunPos = new Vector2(transform.position.x + armLength, transform.position.y);
        GameObject gun = Instantiate(startingGun, transform.position, Quaternion.identity) as GameObject;
        gun.transform.parent = transform;
        gun.GetComponent<gunStats>().combo = comboObject;

        //Instantiate(score);
        //Instantiate(spawner);

        //GameObject armObject = Instantiate(arm) as GameObject;
        //armObject.transform.parent = transform;


    }

    // Update is called once per frame
    void Update() {

    }
}
