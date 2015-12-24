using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class healthBar : MonoBehaviour {
    public GameObject fill;
    public Image fillImage;
    public Text healthText;

    public GameObject gru;
    public gruStats stats;
	// Use this for initialization
	void Start () {
        fillImage = fill.GetComponent<Image>();
        stats = gru.GetComponent<gruStats>();
    }
	
	// Update is called once per frame
	void Update () {
        fillImage.fillAmount = stats.health / 100f;
        healthText.text = stats.health.ToString();

    }
}
