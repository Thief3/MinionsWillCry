using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour {
    public float radius; // If you change the camera zoom you must change this;
    public float spawnEveryXSecs;
    private float deltaTime;
    private float timer;
    private randomGen randomMinion;
    private randomPrefab minionsPrefab;

	// Use this for initialization
	void Start () {
        randomMinion = GetComponent<randomGen>();
        deltaTime = 0;
        timer = 0;
	}
	
	// Update is called once per frame
	void Update () {
        deltaTime += Time.deltaTime;
        timer += Time.deltaTime;

        if(deltaTime >= spawnEveryXSecs) {
            deltaTime -= spawnEveryXSecs;

            Vector2 spawnPos = transform.position;
            while (!((Camera.main.WorldToViewportPoint(spawnPos).x < 0
                || Camera.main.WorldToViewportPoint(spawnPos).x > 1)
                && (Camera.main.WorldToViewportPoint(spawnPos).y < 0
                || Camera.main.WorldToViewportPoint(spawnPos).y > 1))){

                spawnPos = new Vector2(
                    Random.Range(transform.position.x - radius, transform.position.x + radius),
                    Random.Range(transform.position.y - radius, transform.position.y + radius));
            }

            minionsPrefab = randomMinion.GetRandom();
            Debug.Log(minionsPrefab);

            GameObject minion = Instantiate(minionsPrefab.prefab, spawnPos, Quaternion.identity) as GameObject;
            minion.GetComponent<minionStats>().gru = transform.parent.gameObject;
        }
    }
}
