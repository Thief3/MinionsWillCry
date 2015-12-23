using UnityEngine;
using System.Collections;

public class minionStats : MonoBehaviour {
    //Combo Object set at spawn
    public int health, dmg;
    public float speed;
    public GameObject gru;
    public GameObject comboObject;

    private randomGen randomDrop;
    private randomPrefab selectedDrop;

    private styleCombos comboF;

    // Use this for initialization
    void Start () {
        randomDrop = GetComponent<randomGen>();
        comboObject = gru.GetComponent<gruStats>().combo;
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
            DestroySelf();
        }
    }

    public void DestroySelf() {
        comboF.AddDeath();
        selectedDrop = randomDrop.GetRandom();

        if (selectedDrop != null) {
            Instantiate(selectedDrop.prefab, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);   
    }


}
