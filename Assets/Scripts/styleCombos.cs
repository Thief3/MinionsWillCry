using UnityEngine;
using System.Collections;

public class styleCombos : MonoBehaviour {
    public float stylePoints;
    public float stylishMulti;
    public float sylishMultiDefault;
    public float timerMultiDecreasePerSecond;
    public float minMultiThresold;

	// Use this for initialization
	void Start () {
        stylishMulti = sylishMultiDefault;
        stylePoints = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (stylishMulti > minMultiThresold) {
            stylishMulti -= Time.deltaTime * timerMultiDecreasePerSecond;
            //rank
        }
         
	}

    public void ResetMulit() {
        stylishMulti = 0f;
    }

    public void ResetPoints () {
        stylePoints = 0f;
    }

    public void AddHit() {
        stylePoints += stylishMulti;
    }

    public void AddDeath() {
        //score.AddToScore()
        stylePoints += stylishMulti;
    }

}
