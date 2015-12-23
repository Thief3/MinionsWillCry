using UnityEngine;
using System.Collections;

public class styleCombos : MonoBehaviour {
    public float stylePoints;
    public float stylishMulti;
    public float stylishMultiDefault;
    public float timerMultiDecreasePerSecond;
    public float minMultiThresold;
    public float basePerKill;

	// Use this for initialization
	void Start () {
        stylishMulti = stylishMultiDefault;
        stylePoints = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (stylishMulti - Time.deltaTime * timerMultiDecreasePerSecond > minMultiThresold) {
            stylishMulti -= Time.deltaTime * timerMultiDecreasePerSecond;
            //rank
        }
         
	}

    public void ResetMulit() {
        stylishMulti = stylishMultiDefault;
    }

    public void ResetPoints () {
        stylePoints = 0f;
        stylishMulti = stylishMultiDefault;
    }

    public void AddHit() {
        stylePoints += stylishMulti;
    }

    public void AddDeath() {
        //score.AddToScore()
        stylePoints += stylishMulti;
        Debug.Log("SPoints: " + stylePoints.ToString());
        Debug.Log("SMulti: " + stylishMulti.ToString());
        Debug.Log("Points To Add: " + Mathf.Floor(stylePoints * basePerKill).ToString());
        score.AddToScore(Mathf.Floor(stylishMulti * basePerKill));
    }

}
