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
    private Animator anim;

    private float timer;
    private bool died;

    // Use this for initialization
    void Start () {
        timer = 0f;
        died = false;
        anim = GetComponent<Animator>();
        randomDrop = GetComponent<randomGen>();
        comboObject = gru.GetComponent<gruStats>().combo;
        comboF = comboObject.GetComponent<styleCombos>();
        
    }
	
	// Update is called once per frame
	void Update () {
	    if (died) {
            timer += Time.deltaTime;
            if (timer >= anim.playbackTime) {
                selectedDrop = randomDrop.GetRandom();

                if (selectedDrop != null) {
                    Instantiate(selectedDrop.prefab, transform.position, Quaternion.identity);
                }

                Destroy(gameObject);
            }
        }
	}
    
    public void LoseHealth(int hitValue) {
        if (health - hitValue > 0) {
            health -= hitValue;
            anim.SetTrigger("Hit");
        }
        else {
            health = 0;
            DestroySelf();
        }
    }

    public void DestroySelf() {
        anim.SetTrigger("Die");
        comboF.AddDeath();

        died = true;
    }


}
