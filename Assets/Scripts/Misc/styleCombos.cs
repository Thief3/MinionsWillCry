using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class styleCombos : MonoBehaviour {
    public float stylePoints;
    public float stylishMulti;
    public float stylishMultiDefault;
    public float timerMultiDecreasePerSecond;
    public float minMultiThresold;
    public float basePerKill;
    public GameObject comboTextObject;
    private Text comboText;
    public styleRank[] styleRanks;
	// Use this for initialization
	void Start () {
        stylishMulti = stylishMultiDefault;
        stylePoints = 0f;
        comboText = comboTextObject.GetComponent<Text>();
        comboText.text = "test";
    }
	
	// Update is called once per frame
	void Update () {
        if (stylishMulti - Time.deltaTime * timerMultiDecreasePerSecond > minMultiThresold) {
            stylishMulti -= Time.deltaTime * timerMultiDecreasePerSecond;
            //rank
        }

        // Make this customisable later
        for(int i = 0; i < styleRanks.Length; i++) {
            //Debug.Log("entering loop");
            if (stylePoints >= styleRanks[i].minThresold) {
               // Debug.Log("Entered if");
                comboText.text = styleRanks[i].text;
                i = styleRanks.Length;
            }
        }

        if (stylePoints < 0) {
            comboText.text = "... How? This shouldn't be possible?";
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
       // Debug.Log("SPoints: " + stylePoints.ToString());
      //  Debug.Log("SMulti: " + stylishMulti.ToString());
       // Debug.Log("Points To Add: " + Mathf.Floor(stylePoints * basePerKill).ToString());
        score.AddToScore(Mathf.Floor(stylishMulti * basePerKill));
    }

}
