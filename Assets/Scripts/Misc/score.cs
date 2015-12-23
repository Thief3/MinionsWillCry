using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class score : MonoBehaviour {
    static public float points;
    static public void AddToScore (float x) {
        points += x;
        Debug.Log("Points Added!: " + points.ToString());
    }
}
