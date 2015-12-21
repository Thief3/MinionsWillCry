using UnityEngine;
using System.Collections;

public class minionStats : MonoBehaviour {
    //Combo Object set at spawn
    public int health, dmg;
    public float speed;
    public GameObject gru;
    public GameObject comboObject;

    private styleCombos comboF;

    // Use this for initialization
    void Start () {
        comboF = comboObject.GetComponent<styleCombos>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void LoseHealth(int hitValue) {
        if (health - hitValue > 0) {
            health -= hitValue;
        }
        else {
            health = 0;
            DestroySelf();
        }
    }

    void DestroySelf() {
        comboF.AddDeath();
        Destroy(gameObject);   
    }


}
