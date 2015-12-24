using UnityEngine;
using System.Collections;

public class destroySelfAfterTime : MonoBehaviour {
    public float timeBeforeDissapation;
    private float timer;
    // Use this for initialization
    void Start() {
        timer = 0f;
    }

    // Update is called once per frame
    void Update() {
        timer += Time.deltaTime;
        if (timer >= timeBeforeDissapation) {
            Destroy(gameObject);
        }
    }
}
