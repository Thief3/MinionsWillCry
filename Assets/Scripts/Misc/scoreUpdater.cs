using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class scoreUpdater : MonoBehaviour {
    private Text textObj;
	// Use this for initialization
	void Start () {
        textObj = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log("Happening? " + score.points.ToString());
        textObj.text = (Mathf.FloorToInt(score.points)).ToString();
    }
}
