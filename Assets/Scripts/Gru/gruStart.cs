﻿using UnityEngine;
using System.Collections;

public class gruStart : MonoBehaviour {
    public GameObject comboObject;
    public GameObject startingGun;
    public GameObject startingSecondary;
    //public GameObject score;
    public GameObject spawnerPrefab;

    public GameObject gui;

    // Use this for initialization
    void Start() {
        GameObject guiInstance = Instantiate(gui) as GameObject;
        guiInstance.GetComponent<healthBar>().gru = gameObject;
        GetComponent<gruStats>().ui = guiInstance;

        GetComponent<gruStats>().combo = guiInstance;
        GetComponent<gruStats>().combof = guiInstance.GetComponent<styleCombos>();

        GameObject gun = Instantiate(startingGun, transform.position, Quaternion.identity) as GameObject;
        
        gun.transform.parent = transform;
        gun.GetComponent<gunStats>().combo = GetComponent<gruStats>().combo;
        GetComponent<gruStats>().gun = gun;

        GameObject grenadeToss = Instantiate(startingSecondary, transform.position, Quaternion.identity) as GameObject;
        GetComponent<gruStats>().grenadeToss = grenadeToss;
        grenadeToss.transform.parent = transform;
        grenadeToss.GetComponent<gunStats>().combo = GetComponent<gruStats>().combo;

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
