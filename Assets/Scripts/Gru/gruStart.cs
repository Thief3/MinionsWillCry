using UnityEngine;
using System.Collections;

public class gruStart : MonoBehaviour {
    public GameObject comboObject;
    public GameObject startingGun;
    //public GameObject score;
    public GameObject spawnerPrefab;

    public GameObject healthBar;

    // Use this for initialization
    void Start() {
        GameObject health = Instantiate(healthBar) as GameObject;
        health.GetComponent<healthBar>().gru = gameObject;

       // Instantiate(score);
        GetComponent<gruStats>().combo = Instantiate(comboObject) as GameObject;
        GetComponent<gruStats>().combof = GetComponent<gruStats>().combo.GetComponent<styleCombos>();
        GameObject gun = GetComponent<gruStats>().gun;
        gun = Instantiate(startingGun, transform.position, Quaternion.identity) as GameObject;
        gun.transform.parent = transform;
        gun.GetComponent<gunStats>().combo = GetComponent<gruStats>().combo;
        //GetComponent<gruStats>().gunChange(startingGun);

        GameObject spawnerObject = Instantiate(spawnerPrefab) as GameObject;
        spawnerObject.transform.parent = transform;

        //GameObject armObject = Instantiate(arm) as GameObject;
        //armObject.transform.parent = transform;


    }

    // Update is called once per frame
    void Update() {

    }
}
